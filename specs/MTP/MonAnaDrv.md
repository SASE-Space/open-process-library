# MonAnaDrv

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

| Variable   | Source | Var Type | Data Type | Description                                                      | Functionality |
| ---------- | ------ | -------- | --------- | ---------------------------------------------------------------- | ------------- |
| WQC        | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | TODO          |
| oSLevel    | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | TODO          |
| safePos    | PEA    | Input    | Bool      | Safe Position. 0: close, 1: running                              | TODO          |
| safePosAct | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                            | TODO          |
| fwdEn      | PEA    | Input    | Bool      | Forward enable                                                   | TODO          |
| revEn      | PEA    | Input    | Bool      | Reverse enable                                                   | TODO          |
| stopOp     | POL    | Local    | Bool      | Stop command by operator                                         | TODO          |
| fwdOp      | POL    | Local    | Bool      | Forward command by operator                                      | TODO          |
| revOp      | POL    | Local    | Bool      | Reverse command by operator                                      | TODO          |
| stopAut    | PEA    | Input    | Bool      | Open command from controller program                             | TODO          |
| fwdAut     | PEA    | Input    | Bool      | Forward command from controller program                          | TODO          |
| revAut     | PEA    | Input    | Bool      | Reverse command from controller program                          | TODO          |
| fwdCtrl    | PEA    | Output   | Bool      | Forward Control command to hardware                              | TODO          |
| revCtrl    | PEA    | Output   | Bool      | Reverse Control command to hardware                              | TODO          |
| rpmSclMin  | PEA    | Input    | Real      | RPM Setpoint Scale Low Limit                                     | TODO          | TODO: RPM or %?
| rpmSclMax  | PEA    | Input    | Real      | RPM Setpoint Scale High Limit                                    | TODO          |
| rpmUnit    | PEA    | Input    | Int       | RPM Setpoint Unit                                                | TODO          |
| rpmMin     | PEA    | Input    | Real      | RPM Setpoint Low Limit                                           | TODO          |
| rpmMax     | PEA    | Input    | Real      | RPM Setpoint High Limit                                          | TODO          |
| rpmInt     | PEA    | Input    | Real      | RPM Internal Setpoint                                            | TODO          |
| rpmMan     | POL    | Local    | Real      | RPM Manual Setpoint                                              | TODO          |
| rpmRbk     | PEA    | Local    | Real      | RPM Readback Signal                                              | TODO          |
| rpm        | PEA    | Output   | Real      | RPM Setpoint                                                     | TODO          |
| revFbkCalc | PEA    | Input    | Bool      | Reverse feedback is Calculated                                   | TODO          |
| revFbk     | PEA    | Input    | Bool      | Reverse feedback from the hardware                               | TODO          |
| fwdFbkCalc | PEA    | Input    | Bool      | Forward feedback is calculated                                   | TODO          |
| fwdFbk     | PEA    | Input    | Bool      | Forward feedback from the hardware                               | TODO          |
| rpmFbkCalc | PEA    | Input    | Bool      | RPM Feedback Source. 0: sensor, 1: calculated                    | TODO          |
| rpmFbk     | PEA    | Input    | Real      | RPM Feedback Signal                                              | TODO          |
| trip       | PEA    | Input    | Bool      | Drive Protection Indicator. 0: tripped, 1: no error              | TODO          |
| resetOp    | POL    | Local    | Bool      | Reset command by operator                                        | TODO          |
| resetAut   | PEA    | Input    | Bool      | Reset command from controller program                            | TODO          |
| monEn      | POL    | Local    | Bool      | Monitor Enable. 1: enabled                                       | TODO          |
| monSafePos | PEA    | Input    | Bool      | Behaviour if monitoring error. 1 = safe pos, 0 = hold pos        | TODO          |
| monStatErr | PEA    | Output   | Bool      | Static monitoring error occurred                                 | TODO          |
| monDynErr  | PEA    | Output   | Bool      | Dynamic Monitoring error occurred                                | TODO          |
| monStatTi  | PEA    | Input    | Real      | monitor time for static changes, in s                            | TODO          |
| monDynTi   | PEA    | Input    | Real      | monitor time for dynamic changes, in s                           | TODO          |
