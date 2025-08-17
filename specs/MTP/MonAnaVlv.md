# MonAnaVlv

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

| Variable     | Source | Var Type | Data Type | Description                                                         | Functionality |
| ------------ | ------ | -------- | --------- | ------------------------------------------------------------------- | ------------- |
| WQC          | PEA    | Input    | Byte      | Worst Quality Code Variable                                         | TODO          |
| OSLevel      | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL    | TODO          |
| SafePos      | PEA    | Input    | Bool      | Safe Position. 0: posMin, 1: posMax                                 | TODO          |
| SafePosEn    | PEA    | Input    | Bool      | Safe Position Enable. 1: has safe position, 0: has no safe position | TODO          |
| SafePosAct   | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                               | TODO          |
| OpenAut      | PEA    | Input    | Bool      | Open command from controller program                                | TODO          |
| CloseAut     | PEA    | Input    | Bool      | Close command from controller program                               | TODO          |
| OpenOp       | POL    | Local    | Bool      | Open command by operator                                            | TODO          |
| CloseOp      | POL    | Local    | Bool      | Close command by operator                                           | TODO          |
| OpenAct      | PEA    | Output   | Bool      | Valve is set to Open                                                | TODO          |
| CloseAct     | PEA    | Output   | Bool      | Valve is set to Close                                               | TODO          |
| PosSclMin    | PEA    | Input    | Real      | Position Setpoint Scale Low Limit                                   | TODO          | TODO: Limit = range?
| PosSclMax    | PEA    | Input    | Real      | Position Setpoint Scale High Limit                                  | TODO          |
| PosUnit      | PEA    | Input    | Int       | Position Setpoint Unit                                              | TODO          |
| PosMin       | PEA    | Input    | Real      | Position Setpoint Low Limit                                         | TODO          |
| PosMax       | PEA    | Input    | Real      | Position Setpoint High Limit                                        | TODO          |
| PosInt       | PEA    | Input    | Real      | Position Internal Setpoint                                          | TODO          |
| PosMan       | POL    | Local    | Real      | Position Manual Setpoint                                            | TODO          |
| PosRbk       | PEA    | Local    | Real      | Position Readback Signal                                            | TODO          |
| Pos          | PEA    | Output   | Real      | Position Setpoint                                                   | TODO          | TODO: raw value?
| OpenFbkCalc  | PEA    | Input    | Bool      | Open Feedback Source. 0: sensor, 1: calculated                      | TODO          |
| OpenFbk      | PEA    | Input    | Bool      | Open Feedback Signal                                                | TODO          |
| CloseFbkCalc | PEA    | Input    | Bool      | Close Feedback Source. 0: sensor, 1: calculated                     | TODO          |
| CloseFbk     | PEA    | Input    | Bool      | Close Feedback Signal                                               | TODO          |
| PosFbkCalc   | PEA    | Input    | Bool      | Position Feedback Source. 0: sensor, 1: calculated                  | TODO          |
| PosFbk       | PEA    | Input    | Real      | Position Feedback Signal                                            | TODO          |
| ResetOp      | POL    | Local    | Bool      | Reset command by operator                                           | TODO          |
| ResetAut     | POL    | Input    | Bool      | Reset command from controller program                               | TODO          |
|              |        |          |           |                                                                     | TODO          |
