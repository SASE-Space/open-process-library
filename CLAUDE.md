# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Project Overview

The Open Process Library (OPL) is an open-source initiative to create standardized process automation function blocks that work across different PLC/DCS systems. It's based on the Module Type Package (MTP) standard and aims to solve the vendor lock-in problem in industrial automation.

## Development Commands

This project uses Deno for its build scripts. Here are the essential commands:

```bash
# Generate all function blocks from specifications
deno run --allow-read --allow-write scripts/generate.ts

# Generate only specific function blocks (filter by name)
deno run --allow-read --allow-write scripts/generate.ts DigitalInput

# The generator will:
# 1. Parse markdown specs from specs/Library/ and specs/MTP/
# 2. Generate code using templates in templates/
# 3. Output to generated/FunctionBlocks/[template-name]/
# 4. Create generated/model/model.json with parsed data
```

## Architecture and Code Structure

### Key Directories

- **specs/**: Markdown specification files defining function blocks
  - **Library/**: OPL-specific function block implementations
  - **MTP/**: Standard MTP interface definitions
- **templates/**: Code generation templates (Eta templating engine)
  - Each subdirectory represents a different output format/vendor
  - **beckhoff-linked/**: Generates PLCopen XML for Beckhoff TwinCAT
  - **demo/**: Simple text output for testing
- **scripts/generate.ts**: Main code generator script
- **generated/**: Output directory for generated code (add to .gitignore)

### Function Block Architecture

Each function block follows a nested architecture:
1. **MTP Interface**: Standard interface defined by MTP specification
2. **OPL Implementation**: Wraps MTP interface with additional functionality
3. **Vendor-specific output**: Generated code for specific PLC/DCS systems

### Specification Format

Function block specifications use structured markdown with these key sections:
- **Variable Table**: Defines inputs, outputs, and internal variables
- **Functionality Table**: Maps variables to expressions/logic
- **State Machine**: Defines states and transitions (where applicable)

Example variable table structure:
```markdown
| Variable | Var Type | Data Type | Description | MTP |
|----------|----------|-----------|-------------|-----|
| Out | Output | Real | Analog output value | AnaView.V |
```

### Code Generation Process

1. **Parser** (scripts/generate.ts:71-180): Extracts tables from markdown
2. **Model Builder**: Creates structured data from parsed tables
3. **Template Renderer**: Uses Eta templates to generate target code
4. **File Writer**: Outputs to appropriate directories

### Adding New Vendor Support

To add support for a new PLC/DCS system:
1. Create a new directory under `templates/` with vendor name
2. Add template files using Eta syntax
3. Templates receive the parsed model data structure
4. Run generator to produce vendor-specific output

## Important Technical Details

- **Runtime**: Deno (not Node.js) - no package.json needed
- **Template Engine**: Eta (similar to EJS but more powerful)
- **Parser**: Custom markdown table parser in scripts/generate.ts
- **No test framework** currently implemented
- **No linting** or formatting configuration

## Working with Specifications

When modifying function block specifications:
1. Both Library and MTP specs should be updated together
2. Variable names in Library specs often reference MTP paths (e.g., `AnaView.V`)
3. State machines use specific format: State | Actions | Transition Condition | Target
4. Functionality tables map outputs to expressions using TypeScript-like syntax

## Common Tasks

### Creating a New Function Block
1. Create specification in `specs/Library/NewBlock.md`
2. Create corresponding MTP spec in `specs/MTP/NewBlock.md`
3. Follow existing patterns for variable tables and state machines
4. Run generator to verify output

### Modifying Templates
1. Templates are in `templates/[vendor]/`
2. Use Eta syntax: `<%= variable %>` for output, `<% code %>` for logic
3. Access model data via `it` object (e.g., `it.blocks`, `it.name`)
4. Run generator with specific block name to test changes quickly

### Debugging Generation Issues
1. Check generated/model/model.json to verify parsing
2. Add console.log statements in scripts/generate.ts
3. Template errors will show line numbers in the template file
4. Use `deno run` with `--inspect` flag for debugging