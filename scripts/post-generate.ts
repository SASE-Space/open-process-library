// Generic post-generation script
// Generates templates.json file for beckhoff-linked Library directory

export async function postGenerate() {
    const targetDir = '/mnt/d/p2/open-process-library/generated/FunctionBlocks/beckhoff-linked/Library'
    
    try {
        // Read files from the target directory
        const files = []
        
        try {
            for await (const dirEntry of Deno.readDir(targetDir)) {
                if (dirEntry.isFile && dirEntry.name.endsWith('.xml') && dirEntry.name !== 'templates.json') {
                    files.push({
                        "Name": dirEntry.name,
                        "Type": "cm_type"
                    })
                }
            }
        } catch (error) {
            console.error(`Error reading directory ${targetDir}:`, error)
            return
        }
        
        // Create templates.json structure
        const templatesData = {
            "Templates": files
        }
        
        // Write templates.json file
        const outputPath = `${targetDir}/templates.json`
        await Deno.writeTextFile(outputPath, JSON.stringify(templatesData, null, 4))
        
        console.log(`Generated templates.json with ${files.length} files in ${outputPath}`)
        
        // Execute external script
        console.log('Executing external script...')
        try {
            const scriptPath = 'local-import-with-local-templates.sh'
            const workingDir = '/mnt/d/p/acc-workstream-mtp/scripts/cli'
            
            const command = new Deno.Command('bash', {
                args: [scriptPath],
                cwd: workingDir,
                stdout: 'inherit',
                stderr: 'inherit'
            })
            
            const { code } = await command.output()
            
            if (code === 0) {
                console.log('External script executed successfully')
            } else {
                console.error(`External script failed with exit code: ${code}`)
            }
        } catch (scriptError) {
            console.error('Error executing external script:', scriptError)
        }
        
    } catch (error) {
        console.error('Error in post-generate script:', error)
    }
}

// Allow direct execution if run as main script
if (import.meta.main) {
    await postGenerate()
}