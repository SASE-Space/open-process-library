import nunjucks from "https://esm.sh/nunjucks@3.2.4"

console.log("Hello World")

const fileFilter = Deno.args[0] // Optional filename filter
if (fileFilter) {
    console.log(`Processing only files matching: ${fileFilter}`)
}

const model = { FunctionBlocks: [] }
// Configure Nunjucks environment
nunjucks.configure(['templates'], {
    autoescape: false,
    throwOnUndefined: false
})
const stateMachines: { [key: string]: any } = {}
const generatedFunctionBlocks: { [key: string]: any } = {}

// Helper functions that were previously in ETA templates
function getVariablesByType(variables: any, varType: string) {
    return Object.keys(variables).filter(name => 
        variables[name]['Var Type'] === varType
    ).map(name => ({ name, ...variables[name] }));
}

function getAllFunctionality(functionality: any) {
    return Object.keys(functionality)
        .filter(key => ['Expression', 'Explanation', 'Set', 'Reset', 'BlankLine', 'StateMachine'].includes(functionality[key].LogicType))
        .filter(key => {
            const func = functionality[key];
            return (func.LogicType === 'Expression' && func.Expression) || 
                   (func.LogicType === 'Explanation' && func.Comment) ||
                   (func.LogicType === 'Set' && func.Set) ||
                   (func.LogicType === 'Reset' && func.Reset) ||
                   (func.LogicType === 'BlankLine') ||
                   (func.LogicType === 'StateMachine' && func.StateMachine);
        })
        .map(key => ({
            key,
            logicType: functionality[key].LogicType,
            expression: functionality[key].Expression,
            comment: functionality[key].Comment,
            set: functionality[key].Set,
            reset: functionality[key].Reset,
            stateMachine: functionality[key].StateMachine,
            delayVariable: functionality[key].DelayVariable,
            setDelayVariable: functionality[key].SetDelayVariable,
            resetDelayVariable: functionality[key].ResetDelayVariable,
            delayTimerNumber: functionality[key].DelayTimerNumber,
            setDelayTimerNumber: functionality[key].SetDelayTimerNumber,
            resetDelayTimerNumber: functionality[key].ResetDelayTimerNumber
        }));
}

function parseVariableTable(content: string, functionBlock: any) {
    const lines = content.split('\n')
    let inVariableTable = false
    let inVariableTablesSection = false
    let tableHeaders: string[] = []
    
    for (let i = 0; i < lines.length; i++) {
        const line = lines[i].trim()
        
        // Check if this line contains "Variable Table" or "Variable Tables" heading
        if (line.toLowerCase().includes('variable table')) {
            if (line.toLowerCase().includes('variable tables')) {
                // Plural case - process all sub-tables
                inVariableTablesSection = true
                inVariableTable = false
            } else {
                // Singular case - process single table
                inVariableTable = true
                inVariableTablesSection = false
            }
            continue
        }
        
        if (inVariableTable || inVariableTablesSection) {
            // Skip empty lines
            if (!line) continue
            
            
            // Check if this is a table row (starts and ends with |)
            if (line.startsWith('|') && line.endsWith('|')) {
                const cells = line.split('|').map(cell => cell.trim()).slice(1, -1) // Remove first/last empty elements from | boundaries
                
                // Check if this is the separator row (contains dashes)
                if (cells.every(cell => cell.match(/^-+$/))) {
                    continue
                }
                
                // If we don't have headers yet, this is the header row
                if (tableHeaders.length === 0) {
                    tableHeaders = cells
                    continue
                }
                
                // This is a data row - parse the variable
                if (cells.length > 0 && tableHeaders[0].toLowerCase() === 'variable') {
                    // Pad cells array with empty strings for missing columns
                    while (cells.length < tableHeaders.length) {
                        cells.push('')
                    }
                    
                    const variableName = cells[0]
                    const variableData: any = {}
                    
                    // Add all other columns as properties
                    for (let j = 1; j < tableHeaders.length; j++) {
                        variableData[tableHeaders[j]] = cells[j]
                    }
                    
                    functionBlock.Variables[variableName] = variableData
                }
            } else if (line.startsWith('#')) {
                // Check stopping condition based on mode
                if (inVariableTable) {
                    // Singular case: stop at any heading
                    break
                } else if (inVariableTablesSection) {
                    // Plural case: only stop at ## level headings (major sections)
                    if (line.startsWith('##') && !line.startsWith('###') && !line.toLowerCase().includes('variable')) {
                        break
                    }
                    // Reset headers when starting a new sub-table (### level)
                    if (line.startsWith('###')) {
                        tableHeaders = []
                        continue
                    }
                }
            }
        }
    }
}

function parseStateMachines(content: string, functionBlock: any) {
    const lines = content.split('\n')
    
    for (let i = 0; i < lines.length; i++) {
        const line = lines[i].trim()
        
        // Check if this line contains "State Machine" heading
        if (line.includes('State Machine') && line.match(/^#+\s+/)) {
            // Extract state machine name (everything before " State Machine")
            const headingText = line.replace(/^#+\s+/, '')
            const stateMachineName = headingText.replace(' State Machine', '')
            
            if (stateMachineName === headingText) {
                // Heading doesn't contain " State Machine", skip
                continue
            }
            
            // Parse the state machine table starting from this point
            const stateMachine = parseStateMachineTable(lines, i + 1, stateMachineName, functionBlock)
            if (stateMachine) {
                stateMachines[stateMachineName] = stateMachine
            }
        }
    }
}

function parseStateMachineTable(lines: string[], startIndex: number, stateMachineName: string, functionBlock: any): any | null {
    let tableHeaders: string[] = []
    let currentState = ''
    let currentStateData: any = null
    let currentTransitionConditions: string[] = []
    let states: { [key: string]: any } = {}
    
    for (let i = startIndex; i < lines.length; i++) {
        const line = lines[i].trim()
        
        // Skip empty lines
        if (!line) continue
        
        // Stop if we hit another section
        if (line.startsWith('#')) {
            break
        }
        
        // Check if this is a table row
        if (line.startsWith('|') && line.endsWith('|')) {
            const cells = line.split('|').map(cell => cell.trim()).slice(1, -1)
            
            // Check if this is the separator row
            if (cells.every(cell => cell.match(/^-+$/))) {
                continue
            }
            
            // If we don't have headers yet, this is the header row
            if (tableHeaders.length === 0) {
                tableHeaders = cells
                continue
            }
            
            // Pad cells array
            while (cells.length < tableHeaders.length) {
                cells.push('')
            }
            
            // Process data row
            if (cells.length > 0 && tableHeaders[0].toLowerCase() === 'state') {
                const stateCell = cells[0]
                const actionsCell = cells[1] || ''
                const transitionConditionCell = cells[2] || ''
                const targetCell = cells[3] || ''
                
                // Check if this is a new state or continuation
                if (stateCell !== '') {
                    // Save previous state if it exists
                    if (currentState !== '' && currentStateData) {
                        states[currentState] = currentStateData
                    }
                    
                    // Parse new state
                    const stateMatch = stateCell.match(/^(\d+)\s*\(([^)]+)\)$/)
                    if (!stateMatch) {
                        console.error(`Error parsing state machine "${stateMachineName}": Malformed state entry "${stateCell}". Expected format: "0 (Name)". Skipping table.`)
                        return null
                    }
                    
                    const stateNumber = stateMatch[1]
                    const stateName = stateMatch[2]
                    
                    currentState = stateNumber
                    currentStateData = {
                        Name: stateName,
                        Actions: [], // Empty for now
                        Transitions: {}
                    }
                    currentTransitionConditions = []
                }
                
                // Handle transition condition
                if (transitionConditionCell !== '') {
                    currentTransitionConditions.push(transitionConditionCell)
                }
                
                // Handle target (end of transition)
                if (targetCell !== '' && currentState !== '') {
                    const combinedCondition = currentTransitionConditions.join(' ').trim()
                    if (combinedCondition) {
                        // Parse delay variable from the condition
                        const delayParsed = parseDelayVariable(combinedCondition)
                        currentStateData.Transitions[targetCell] = {
                            Condition: delayParsed.condition,
                            DelayVariable: delayParsed.delayVariable,
                            DelayTimerNumber: delayParsed.delayVariable ? assignTimerNumber(functionBlock, delayParsed.delayVariable) : null
                        }
                    }
                    currentTransitionConditions = []
                }
            }
        }
    }
    
    // Save last state
    if (currentState !== '' && currentStateData) {
        states[currentState] = currentStateData
    }
    
    return Object.keys(states).length > 0 ? states : null
}

function parseFunctionalityTable(content: string, functionBlock: any) {
    const lines = content.split('\n')
    let inFunctionalityTable = false
    let tableHeaders: string[] = []
    let currentTarget = ''
    let targetData: any = {}
    let explanationCounter = 1
    let blankLineCounter = 1
    
    for (let i = 0; i < lines.length; i++) {
        const line = lines[i].trim()
        
        // Check if this line contains "Functionality" heading
        if (line.toLowerCase().includes('functionality') && line.startsWith('#')) {
            inFunctionalityTable = true
            continue
        }
        
        if (inFunctionalityTable) {
            // Skip empty lines
            if (!line) continue
            
            // Check if this is a table row (starts and ends with |)
            if (line.startsWith('|') && line.endsWith('|')) {
                const cells = line.split('|').map(cell => cell.trim()).slice(1, -1) // Remove first/last empty elements from | boundaries
                
                // Check if this is the separator row (contains dashes)
                if (cells.every(cell => cell.match(/^-+$/))) {
                    continue
                }
                
                // If we don't have headers yet, this is the header row
                if (tableHeaders.length === 0) {
                    tableHeaders = cells
                    continue
                }
                
                // Pad cells array with empty strings for missing columns
                while (cells.length < tableHeaders.length) {
                    cells.push('')
                }
                
                // Process data row
                if (cells.length > 0 && tableHeaders[0].toLowerCase() === 'target') {
                    const targetName = cells[0]
                    const mtpValue = cells[1] || ''
                    const expression = cells[2] || ''
                    const comment = cells[3] || ''
                    
                    
                    // Handle empty target rows
                    if (targetName === '') {
                        // Check for completely blank rows (all cells empty or whitespace)
                        if (expression.trim() === '' && comment.trim() === '' && mtpValue.trim() === '') {
                            // Save previous target if exists
                            if (currentTarget !== '') {
                                const result = processTargetData(targetData, functionBlock)
                                if (Array.isArray(result)) {
                                    // If it's an array (Set and Reset), add both with suffixes
                                    result.forEach((item, index) => {
                                        const suffix = item.LogicType === 'Set' ? '_Set' : '_Reset'
                                        functionBlock.Functionality[currentTarget + suffix] = item
                                    })
                                } else {
                                    functionBlock.Functionality[currentTarget] = result
                                }
                            }
                            
                            // Create blank line entry
                            const blankLineKey = `blankLine${blankLineCounter++}`
                            functionBlock.Functionality[blankLineKey] = {
                                LogicType: 'BlankLine',
                                Expression: null,
                                Set: null,
                                Reset: null,
                                StateMachine: null,
                                Comment: null,
                                DelayVariable: null,
                                SetDelayVariable: null,
                                ResetDelayVariable: null,
                                DelayTimerNumber: null,
                                SetDelayTimerNumber: null,
                                ResetDelayTimerNumber: null,
                                isMTP: false
                            }
                            
                            // Reset current target
                            currentTarget = ''
                            targetData = {}
                        } else if (expression.startsWith('//')) {
                            // Save previous target if exists
                            if (currentTarget !== '') {
                                const result = processTargetData(targetData, functionBlock)
                                if (Array.isArray(result)) {
                                    // If it's an array (Set and Reset), add both with suffixes
                                    result.forEach((item, index) => {
                                        const suffix = item.LogicType === 'Set' ? '_Set' : '_Reset'
                                        functionBlock.Functionality[currentTarget + suffix] = item
                                    })
                                } else {
                                    functionBlock.Functionality[currentTarget] = result
                                }
                            }
                            
                            // Create new explanation entry
                            const explanationKey = `explanation${explanationCounter++}`
                            const explanationData = {
                                expressions: [expression],
                                comments: [comment],
                                isMTP: mtpValue.toLowerCase() === 'x'
                            }
                            functionBlock.Functionality[explanationKey] = processTargetData(explanationData)
                            
                            // Reset current target
                            currentTarget = ''
                            targetData = {}
                        } else if (currentTarget !== '') {
                            // Continue previous target (regular expression)
                            if (targetData.expressions) {
                                targetData.expressions.push(expression)
                            }
                            if (targetData.comments) {
                                targetData.comments.push(comment)
                            }
                        }
                    } else {
                        // Save previous target if exists
                        if (currentTarget !== '') {
                            const result = processTargetData(targetData, functionBlock)
                            if (Array.isArray(result)) {
                                // If it's an array (Set and Reset), add both with suffixes
                                result.forEach((item, index) => {
                                    const suffix = item.LogicType === 'Set' ? '_Set' : '_Reset'
                                    functionBlock.Functionality[currentTarget + suffix] = item
                                })
                            } else {
                                functionBlock.Functionality[currentTarget] = result
                            }
                        }
                        
                        // Start new target
                        currentTarget = targetName
                        targetData = {
                            expressions: [expression],
                            comments: [comment],
                            isMTP: mtpValue.toLowerCase() === 'x'
                        }
                    }
                }
            } else if (line.startsWith('#')) {
                // Hit another section, save last target and stop parsing
                if (currentTarget !== '') {
                    const result = processTargetData(targetData, functionBlock)
                    if (Array.isArray(result)) {
                        // If it's an array (Set and Reset), add both with suffixes
                        result.forEach((item, index) => {
                            const suffix = item.LogicType === 'Set' ? '_Set' : '_Reset'
                            functionBlock.Functionality[currentTarget + suffix] = item
                        })
                    } else {
                        functionBlock.Functionality[currentTarget] = result
                    }
                }
                break
            }
        }
    }
    
    // Save last target if we reached end of file
    if (currentTarget !== '') {
        const result = processTargetData(targetData, functionBlock)
        if (Array.isArray(result)) {
            // If it's an array (Set and Reset), add both with suffixes
            result.forEach((item, index) => {
                const suffix = item.LogicType === 'Set' ? '_Set' : '_Reset'
                functionBlock.Functionality[currentTarget + suffix] = item
            })
        } else {
            functionBlock.Functionality[currentTarget] = result
        }
    }
}

function parseDelayVariable(text: string): { condition: string, delayVariable: string | null } {
    const match = text.match(/^(.+)\s+for\s+(\w+)$/)
    if (match) {
        return {
            condition: match[1].trim(),
            delayVariable: match[2].trim()
        }
    }
    return { condition: text, delayVariable: null }
}

function assignTimerNumber(functionBlock: any, delayVariable: string | null): number | null {
    if (!delayVariable) return null
    
    functionBlock.DelayTimerCount++
    return functionBlock.DelayTimerCount
}

function processTargetData(targetData: any, functionBlock: any) {
    const combinedExpression = targetData.expressions.join('\n').trim()
    const combinedComment = targetData.comments.filter((c: string) => c !== '').join('\n').trim()
    
    // Detect LogicType
    let logicType = 'Expression'
    let processedData: any = {
        LogicType: logicType,
        Expression: null,
        Set: null,
        Reset: null,
        StateMachine: null,
        Comment: combinedComment,
        DelayVariable: null,
        SetDelayVariable: null,
        ResetDelayVariable: null,
        DelayTimerNumber: null,
        SetDelayTimerNumber: null,
        ResetDelayTimerNumber: null,
        isMTP: targetData.isMTP
    }
    
    // Check for Explanation (expressions starting with //)
    if (combinedExpression.startsWith('//')) {
        processedData.LogicType = 'Explanation'
        processedData.Comment = combinedExpression.substring(2).trim()
        processedData.Expression = null
        return processedData
    }
    
    // Check for State Machine (single line with exactly 3 words: TargetName State Machine)
    const expressionLines = combinedExpression.split('\n').filter(line => line.trim() !== '')
    if (expressionLines.length === 1) {
        const words = expressionLines[0].trim().split(/\s+/)
        if (words.length === 3 && words[1].toLowerCase() === 'state' && words[2].toLowerCase() === 'machine') {
            processedData.LogicType = 'StateMachine'
            
            // Look up the parsed state machine
            const stateMachineName = words[0]
            if (stateMachines[stateMachineName]) {
                processedData.StateMachine = stateMachines[stateMachineName]
            } else {
                processedData.StateMachine = {}
            }
            return processedData
        }
    }
    
    // Check for SetReset (contains "Set:" or "Reset:")
    if (combinedExpression.includes('Set:') || combinedExpression.includes('Reset:')) {
        const lines = combinedExpression.split('\n')
        let setLines: string[] = []
        let resetLines: string[] = []
        let currentMode = ''
        
        for (const line of lines) {
            const trimmedLine = line.trim()
            if (trimmedLine.startsWith('Set:')) {
                currentMode = 'set'
                const setContent = trimmedLine.substring(4).trim()
                if (setContent) setLines.push(setContent)
            } else if (trimmedLine.startsWith('Reset:')) {
                currentMode = 'reset'
                const resetContent = trimmedLine.substring(6).trim()
                if (resetContent) resetLines.push(resetContent)
            } else if (trimmedLine && currentMode) {
                if (currentMode === 'set') {
                    setLines.push(trimmedLine)
                } else if (currentMode === 'reset') {
                    resetLines.push(trimmedLine)
                }
            }
        }
        
        // Parse delay variables for Set and Reset
        const setExpression = setLines.join(' ').trim()
        const resetExpression = resetLines.join(' ').trim()
        
        let setData: any = null
        let resetData: any = null
        
        if (setExpression) {
            const setParsed = parseDelayVariable(setExpression)
            setData = {
                LogicType: 'Set',
                Expression: null,
                Set: setParsed.condition || null,
                Reset: null,
                StateMachine: null,
                Comment: combinedComment,
                DelayVariable: null,
                SetDelayVariable: setParsed.delayVariable,
                ResetDelayVariable: null,
                DelayTimerNumber: null,
                SetDelayTimerNumber: assignTimerNumber(functionBlock, setParsed.delayVariable),
                ResetDelayTimerNumber: null,
                isMTP: targetData.isMTP
            }
        }
        
        if (resetExpression) {
            const resetParsed = parseDelayVariable(resetExpression)
            resetData = {
                LogicType: 'Reset',
                Expression: null,
                Set: null,
                Reset: resetParsed.condition || null,
                StateMachine: null,
                Comment: combinedComment,
                DelayVariable: null,
                SetDelayVariable: null,
                ResetDelayVariable: resetParsed.delayVariable,
                DelayTimerNumber: null,
                SetDelayTimerNumber: null,
                ResetDelayTimerNumber: assignTimerNumber(functionBlock, resetParsed.delayVariable),
                isMTP: targetData.isMTP
            }
        }
        
        // Return array with both Set and Reset data, or just one if only one exists
        if (setData && resetData) {
            return [setData, resetData]
        } else if (setData) {
            return setData
        } else if (resetData) {
            return resetData
        }
    }
    
    // Default: Expression
    const expressionText = combinedExpression.split('\n').join(' ').trim()
    if (expressionText) {
        const expressionParsed = parseDelayVariable(expressionText)
        processedData.Expression = expressionParsed.condition || null
        processedData.DelayVariable = expressionParsed.delayVariable
        processedData.DelayTimerNumber = assignTimerNumber(functionBlock, expressionParsed.delayVariable)
    }
    return processedData
}

async function processFile(filePath: string, isMTP: boolean) {
    const fileName = filePath.split('/').pop()?.replace('.md', '') || ''
    const content = await Deno.readTextFile(filePath)
    
    const functionBlock = {
        Name: fileName,
        isMTP: isMTP,
        Variables: {},
        Functionality: {},
        DelayTimerCount: 0
    }
    
    // Parse Variable Table if it exists
    parseVariableTable(content, functionBlock)
    
    // Parse State Machines if they exist
    parseStateMachines(content, functionBlock)
    
    // Parse Functionality Table if it exists
    parseFunctionalityTable(content, functionBlock)
    
    model.FunctionBlocks.push(functionBlock)
}

async function readAndProcessFiles(dirPath: string, isMTP: boolean) {
    const files = Deno.readDir(dirPath)
    for await (const file of files) {
        if (file.isFile && file.name.endsWith('.md')) {
            // Skip files that don't match the filter (if provided)
            if (fileFilter && !file.name.includes(fileFilter)) {
                continue
            }
            await processFile(`${dirPath}/${file.name}`, isMTP)
        }
    }
}

// read all the Spec files, process each and add to the Model
await readAndProcessFiles("specs/MTP", true)
await readAndProcessFiles("specs/Library", false)

// Generate code for each function block using all templates
async function generateCode() {
    // Scan template folders
    const templateFolders = Deno.readDir("templates")
    
    for await (const templateFolder of templateFolders) {
        if (templateFolder.isDirectory) {
            const templateFolderName = templateFolder.name
            
            // Configure Nunjucks for this template folder
            nunjucks.configure([`templates/${templateFolderName}`], {
                autoescape: false,
                throwOnUndefined: false
            })
            
            // Scan template files in this folder
            const templateFiles = Deno.readDir(`templates/${templateFolderName}`)
            
            for await (const templateFile of templateFiles) {
                if (templateFile.isFile && templateFile.name.startsWith('FunctionBlockTemplate')) {
                    const templateName = templateFile.name
                        // Generate code for each function block
                    for (const functionBlock of model.FunctionBlocks) {
                        // Create template context with setOutputFile function
                        const templateContext: any = {
                            ...functionBlock,
                            inputVars: getVariablesByType(functionBlock.Variables, 'Input'),
                            outputVars: getVariablesByType(functionBlock.Variables, 'Output'),
                            localVars: getVariablesByType(functionBlock.Variables, 'Local'),
                            allFunctionality: getAllFunctionality(functionBlock.Functionality),
                            variableKeys: Object.keys(functionBlock.Variables),
                            _outputFile: templateName.endsWith('.txt') ? `${functionBlock.Name}.demo` : `${functionBlock.Name}.xml`
                        }
                        
                        const rendered = nunjucks.render(templateName, templateContext)
                        
                        // Use template-defined filename or default
                        const outputFileName = templateContext._outputFile || `${functionBlock.Name}.txt`
                        
                        // Create nested directory structure
                        const blockType = functionBlock.isMTP ? "MTP" : "Library"
                        const outputDir = `generated/FunctionBlocks/${templateFolderName}/${blockType}`
                        const outputPath = `${outputDir}/${outputFileName}`
                        
                        // Store generated code in generatedFunctionBlocks object
                        const blockKey = `${templateFolderName}/${outputFileName}`
                        generatedFunctionBlocks[blockKey] = {
                            folder: outputDir,
                            code: rendered
                        }
                        
                        
                        await Deno.mkdir(outputDir, { recursive: true })
                        await Deno.writeTextFile(outputPath, rendered)
                    }
                }
            }
        }
    }
}

// Second pass: Process ImportTemplate files
async function processImportTemplates() {
    const templateFolders = Deno.readDir("templates")
    
    for await (const templateFolder of templateFolders) {
        if (templateFolder.isDirectory) {
            const templateFolderName = templateFolder.name
            
            // Look for ImportTemplate.xml files
            const templateFiles = Deno.readDir(`templates/${templateFolderName}`)
            
            for await (const templateFile of templateFiles) {
                if (templateFile.isFile && templateFile.name === 'ImportTemplate.nunjucks') {
                    
                    // Configure Nunjucks for ImportTemplate
                    nunjucks.configure([`templates/${templateFolderName}`], {
                        autoescape: false,
                        throwOnUndefined: false
                    })
                    
                    // Filter function blocks to only include those from this template folder
                    const filteredFunctionBlocks: { [key: string]: any } = {}
                    Object.keys(generatedFunctionBlocks).forEach(key => {
                        const block = generatedFunctionBlocks[key]
                        if (key.startsWith(`${templateFolderName}/`)) {
                            filteredFunctionBlocks[key] = block
                        }
                    })
                    
                    
                    // Create template context with filtered function blocks
                    // Convert object to array for easier iteration in Nunjucks
                    const functionBlocksArray = Object.keys(filteredFunctionBlocks).map(key => ({
                        key,
                        ...filteredFunctionBlocks[key]
                    }));
                    
                    const templateContext: any = {
                        generatedFunctionBlocks: functionBlocksArray,
                        _outputFile: 'PLCOpenImport.xml'
                    }
                    
                    // Render as Nunjucks template
                    const rendered = nunjucks.render('ImportTemplate.nunjucks', templateContext)
                    const outputFileName = templateContext._outputFile || 'PLCOpenImport.xml'
                    
                    
                    const outputDir = `generated/FunctionBlocks/${templateFolderName}`
                    const outputPath = `${outputDir}/${outputFileName}`
                    
                    await Deno.mkdir(outputDir, { recursive: true })
                    await Deno.writeTextFile(outputPath, rendered)
                }
            }
        }
    }
}

await generateCode()
await processImportTemplates()
await Deno.mkdir("generated/model", { recursive: true })
await Deno.writeTextFile("generated/model/model.json", JSON.stringify(model, null, 4))