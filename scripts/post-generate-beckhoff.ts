// Post-generation processing for Beckhoff template
// Creates a TwinCAT-compatible version of PLCOpenImport.xml with Beckhoff-specific MTP block references

export async function postGenerateBeckhoff(templateName: string, outputDir: string) {
    console.log(`Post-processing ${templateName} template output in ${outputDir}`)
    
    const sourceFile = `${outputDir}/PLCOpenImport.xml`
    const targetFile = `${outputDir}/PLCOpenImport_UsingTwinCAT_MTP_Blocks.xml`
    
    try {
        // Check if source file exists
        const sourceExists = await Deno.stat(sourceFile).catch(() => null)
        if (!sourceExists) {
            console.log(`Source file ${sourceFile} not found, skipping Beckhoff post-processing`)
            return
        }
        
        // Read the source XML file
        console.log(`Reading ${sourceFile}`)
        const content = await Deno.readTextFile(sourceFile)
        
        // Replace MTP block references with Beckhoff proprietary alternatives
        // This replaces the reference to the MTP blocks from OPL to the proprietary Beckhoff alternatives
        const modifiedContent = content.replace(
            /name="MTPBase"><type><derived name="/g,
            'name="MTPBase"><type><derived name="FB_MTP_'
        )
        
        // Count the number of replacements made
        const matches = content.match(/name="MTPBase"><type><derived name="/g)
        const replacementCount = matches ? matches.length : 0
        
        // Write the modified content to the target file
        await Deno.writeTextFile(targetFile, modifiedContent)
        
        console.log(`Created ${targetFile}`)
        console.log(`Replaced ${replacementCount} MTP block references with Beckhoff FB_MTP_ alternatives`)
        
        if (replacementCount > 0) {
            console.log(`Modified references from OPL MTP blocks to Beckhoff proprietary TwinCAT MTP blocks`)
        }
        
    } catch (error) {
        console.error(`Error during Beckhoff post-processing:`, error)
    }
}