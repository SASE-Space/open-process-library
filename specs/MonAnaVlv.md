# MonAnaVlv

## Variable Table

### Operation Mode

| Variable     | Source | Var Type | Data Type | Description                                                       | Functionality          |
| ------------ | ------ | -------- | --------- | ----------------------------------------------------------------- | ---------------------- |
| stateChannel | PEA    | Input    | Bool      | OperationMode selection. 0: operator (..Op), 1: automatic (..Aut) | from HMI               |
| stateOffAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Offline' in automatic mode              | from Input             |
| stateOpAut   | PEA    | Input    | Bool      | Switch Operation Mode to 'Operator' in automatic mode             | from Input             |
| stateAutAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Automatic' in automatic mode            | from Input             |
| stateOffOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Off' by operator                        | from HMI + (2)         |
| stateOpOp    | POL    | Local    | Bool      | Switch Operation Mode to 'Operator' by operator                   | from HMI + (2)         |
| stateAutOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Automatic' by operator                  | from HMI + (2)         |
| stateOpAct   | PEA    | Output   | Bool      | Operator state active                                             | from state machine (1) |
| stateAutAct  | PEA    | Output   | Bool      | Automatic state active                                            | from state machine (1) |
| stateOffAct  | PEA    | Output   | Bool      | Offline state active                                              | from state machine (1) |

### SourceMode

| Variable   | Source | Var Type | Data Type | Description                                                    | Functionality |
| ---------- | ------ | -------- | --------- | -------------------------------------------------------------- | ------------- |
| srcChannel | PEA    | Input    | Bool      | SourceMode selection. 0: operator (..Op), 1: automatic (..Aut) | TODO          |
| srcManAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Manual' in automatic mode               | TODO          |
| srcIntAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Internal' in automatic mode             | TODO          |
| srcIntOp   | POL    | Local    | Bool      | Switch Source Mode to 'Internal' by operator                   | TODO          |
| srcManOp   | POL    | Local    | Bool      | Switch Source Mode to 'Manual' by operator                     | TODO          |
| srcIntAct  | PEA    | Output   | Bool      | Internal mode active                                           | TODO          |
| srcManAct  | PEA    | Output   | Bool      | Manual mode active                                             | TODO          |

### Interlock

| Variable  | Source | Var Type | Data Type | Description                                                                   | Functionality |
| --------- | ------ | -------- | --------- | ----------------------------------------------------------------------------- | ------------- |
| permEn    | PEA    | Input    | Bool      | Enables the Permission Lock. 1 = enabled (info for HMI)                       | from Input    | TODO: if disabled and still some interlock then error. And don't block interlock because might be misconfigured by accident. Better be safe
| permit    | PEA    | Input    | Bool      | Permit, allows control. Does not activate safe position. 1 = permission given | from Input    |
| intlEn    | PEA    | Input    | Bool      | Enables the Interlock Lock. 1 = enabled (info for HMI)                        | from Input    |
| interlock | PEA    | Input    | Bool      | Interlock, sets safe position. 0 = interlock active                           | from Input    |
| protEn    | PEA    | Input    | Bool      | Enables the Protection Lock. 1 = enabled (info for HMI)                       | from Input    |
| protect   | PEA    | Input    | Bool      | Protect, sets safe position, sets protectState. 0 = Protect active            | from Input    |

### Specific

| Variable     | Source | Var Type | Data Type | Description                                                         | Functionality |
| ------------ | ------ | -------- | --------- | ------------------------------------------------------------------- | ------------- |
| WQC          | PEA    | Input    | Byte      | Worst Quality Code Variable                                         | TODO          |
| oSLevel      | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL    | TODO          |
| safePos      | PEA    | Input    | Bool      | Safe Position. 0: posMin, 1: posMax                                 | TODO          |
| safePosEn    | PEA    | Input    | Bool      | Safe Position Enable. 1: has safe position, 0: has no safe position | TODO          |
| safePosAct   | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                               | TODO          |
| openAut      | PEA    | Input    | Bool      | Open command from controller program                                | TODO          |
| closeAut     | PEA    | Input    | Bool      | Close command from controller program                               | TODO          |
| openOp       | POL    | Local    | Bool      | Open command by operator                                            | TODO          |
| closeOp      | POL    | Local    | Bool      | Close command by operator                                           | TODO          |
| openAct      | PEA    | Output   | Bool      | Valve is set to Open                                                | TODO          |
| closeAct     | PEA    | Output   | Bool      | Valve is set to Close                                               | TODO          |
| posSclMin    | PEA    | Input    | Real      | Position Setpoint Scale Low Limit                                   | TODO          | TODO: Limit = range?
| posSclMax    | PEA    | Input    | Real      | Position Setpoint Scale High Limit                                  | TODO          |
| posUnit      | PEA    | Input    | Int       | Position Setpoint Unit                                              | TODO          |
| posMin       | PEA    | Input    | Real      | Position Setpoint Low Limit                                         | TODO          |
| posMax       | PEA    | Input    | Real      | Position Setpoint High Limit                                        | TODO          |
| posInt       | PEA    | Input    | Real      | Position Internal Setpoint                                          | TODO          |
| posMan       | POL    | Local    | Real      | Position Manual Setpoint                                            | TODO          |
| posRbk       | PEA    | Local    | Real      | Position Readback Signal                                            | TODO          |
| pos          | PEA    | Output   | Real      | Position Setpoint                                                   | TODO          | TODO: raw value?
| openFbkCalc  | PEA    | Input    | Bool      | Open Feedback Source. 0: sensor, 1: calculated                      | TODO          |
| openFbk      | PEA    | Input    | Bool      | Open Feedback Signal                                                | TODO          |
| closeFbkCalc | PEA    | Input    | Bool      | Close Feedback Source. 0: sensor, 1: calculated                     | TODO          |
| closeFbk     | PEA    | Input    | Bool      | Close Feedback Signal                                               | TODO          |
| posFbkCalc   | PEA    | Input    | Bool      | Position Feedback Source. 0: sensor, 1: calculated                  | TODO          |
| posFbk       | PEA    | Input    | Real      | Position Feedback Signal                                            | TODO          |
| resetOp      | POL    | Local    | Bool      | Reset command by operator                                           | TODO          |
| resetAut     | POL    | Input    | Bool      | Reset command from controller program                               | TODO          |
|              |        |          |           |                                                                     | TODO          |
