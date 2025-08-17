# MonAnaDrv

## Variable Table

### Operation Mode

| Variable     | Source | Var Type | Data Type | Description                                                       | Functionality          |
| ------------ | ------ | -------- | --------- | ----------------------------------------------------------------- | ---------------------- |
| StateChannel | PEA    | Input    | Bool      | OperationMode selection. 0: operator (..Op), 1: automatic (..Aut) | from HMI               |
| StateOffAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Offline' in automatic mode              | from Input             |
| StateOpAut   | PEA    | Input    | Bool      | Switch Operation Mode to 'Operator' in automatic mode             | from Input             |
| StateAutAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Automatic' in automatic mode            | from Input             |
| StateOffOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Off' by operator                        | from HMI + (2)         |
| StateOpOp    | POL    | Local    | Bool      | Switch Operation Mode to 'Operator' by operator                   | from HMI + (2)         |
| StateAutOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Automatic' by operator                  | from HMI + (2)         |
| StateOpAct   | PEA    | Output   | Bool      | Operator state active                                             | from state machine (1) |
| StateAutAct  | PEA    | Output   | Bool      | Automatic state active                                            | from state machine (1) |
| StateOffAct  | PEA    | Output   | Bool      | Offline state active                                              | from state machine (1) |

### SourceMode

| Variable   | Source | Var Type | Data Type | Description                                                    | Functionality |
| ---------- | ------ | -------- | --------- | -------------------------------------------------------------- | ------------- |
| SrcChannel | PEA    | Input    | Bool      | SourceMode selection. 0: operator (..Op), 1: automatic (..Aut) | TODO          |
| SrcManAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Manual' in automatic mode               | TODO          |
| SrcIntAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Internal' in automatic mode             | TODO          |
| SrcIntOp   | POL    | Local    | Bool      | Switch Source Mode to 'Internal' by operator                   | TODO          |
| SrcManOp   | POL    | Local    | Bool      | Switch Source Mode to 'Manual' by operator                     | TODO          |
| SrcIntAct  | PEA    | Output   | Bool      | Internal mode active                                           | TODO          |
| SrcManAct  | PEA    | Output   | Bool      | Manual mode active                                             | TODO          |

### Interlock

| Variable  | Source | Var Type | Data Type | Description                                                                   | Functionality |
| --------- | ------ | -------- | --------- | ----------------------------------------------------------------------------- | ------------- |
| PermEn    | PEA    | Input    | Bool      | Enables the Permission Lock. 1 = enabled (info for HMI)                       | from Input    | TODO: if disabled and still some interlock then error. And don't block interlock because might be misconfigured by accident. Better be safe
| Permit    | PEA    | Input    | Bool      | Permit, allows control. Does not activate safe position. 1 = permission given | from Input    |
| IntlEn    | PEA    | Input    | Bool      | Enables the Interlock Lock. 1 = enabled (info for HMI)                        | from Input    |
| Interlock | PEA    | Input    | Bool      | Interlock, sets safe position. 0 = interlock active                           | from Input    |
| ProtEn    | PEA    | Input    | Bool      | Enables the Protection Lock. 1 = enabled (info for HMI)                       | from Input    |
| Protect   | PEA    | Input    | Bool      | Protect, sets safe position, sets protectState. 0 = Protect active            | from Input    |

### Specific

| Variable   | Source | Var Type | Data Type | Description                                                      | Functionality |
| ---------- | ------ | -------- | --------- | ---------------------------------------------------------------- | ------------- |
| WQC        | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | TODO          |
| OSLevel    | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | TODO          |
| SafePos    | PEA    | Input    | Bool      | Safe Position. 0: close, 1: running                              | TODO          |
| SafePosAct | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                            | TODO          |
| FwdEn      | PEA    | Input    | Bool      | Forward enable                                                   | TODO          |
| RevEn      | PEA    | Input    | Bool      | Reverse enable                                                   | TODO          |
| StopOp     | POL    | Local    | Bool      | Stop command by operator                                         | TODO          |
| FwdOp      | POL    | Local    | Bool      | Forward command by operator                                      | TODO          |
| RevOp      | POL    | Local    | Bool      | Reverse command by operator                                      | TODO          |
| StopAut    | PEA    | Input    | Bool      | Open command from controller program                             | TODO          |
| FwdAut     | PEA    | Input    | Bool      | Forward command from controller program                          | TODO          |
| RevAut     | PEA    | Input    | Bool      | Reverse command from controller program                          | TODO          |
| FwdCtrl    | PEA    | Output   | Bool      | Forward Control command to hardware                              | TODO          |
| RevCtrl    | PEA    | Output   | Bool      | Reverse Control command to hardware                              | TODO          |
| RpmSclMin  | PEA    | Input    | Real      | RPM Setpoint Scale Low Limit                                     | TODO          | TODO: RPM or %?
| RpmSclMax  | PEA    | Input    | Real      | RPM Setpoint Scale High Limit                                    | TODO          |
| RpmUnit    | PEA    | Input    | Int       | RPM Setpoint Unit                                                | TODO          |
| RpmMin     | PEA    | Input    | Real      | RPM Setpoint Low Limit                                           | TODO          |
| RpmMax     | PEA    | Input    | Real      | RPM Setpoint High Limit                                          | TODO          |
| RpmInt     | PEA    | Input    | Real      | RPM Internal Setpoint                                            | TODO          |
| RpmMan     | POL    | Local    | Real      | RPM Manual Setpoint                                              | TODO          |
| RpmRbk     | PEA    | Local    | Real      | RPM Readback Signal                                              | TODO          |
| Rpm        | PEA    | Output   | Real      | RPM Setpoint                                                     | TODO          |
| RevFbkCalc | PEA    | Input    | Bool      | Reverse feedback is Calculated                                   | TODO          |
| RevFbk     | PEA    | Input    | Bool      | Reverse feedback from the hardware                               | TODO          |
| FwdFbkCalc | PEA    | Input    | Bool      | Forward feedback is calculated                                   | TODO          |
| FwdFbk     | PEA    | Input    | Bool      | Forward feedback from the hardware                               | TODO          |
| RpmFbkCalc | PEA    | Input    | Bool      | RPM Feedback Source. 0: sensor, 1: calculated                    | TODO          |
| RpmFbk     | PEA    | Input    | Real      | RPM Feedback Signal                                              | TODO          |
| Trip       | PEA    | Input    | Bool      | Drive Protection Indicator. 0: tripped, 1: no error              | TODO          |
| ResetOp    | POL    | Local    | Bool      | Reset command by operator                                        | TODO          |
| ResetAut   | PEA    | Input    | Bool      | Reset command from controller program                            | TODO          |
| MonEn      | POL    | Local    | Bool      | Monitor Enable. 1: enabled                                       | TODO          |
| MonSafePos | PEA    | Input    | Bool      | Behaviour if monitoring error. 1 = safe pos, 0 = hold pos        | TODO          |
| MonStatErr | PEA    | Output   | Bool      | Static monitoring error occurred                                 | TODO          |
| MonDynErr  | PEA    | Output   | Bool      | Dynamic Monitoring error occurred                                | TODO          |
| MonStatTi  | PEA    | Input    | Real      | monitor time for static changes, in s                            | TODO          |
| MonDynTi   | PEA    | Input    | Real      | monitor time for dynamic changes, in s                           | TODO          |
