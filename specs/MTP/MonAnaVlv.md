# MonAnaVlv

## Variable Table

### Operation Mode

| Variable     | Source | Var Type | Data Type | Description                                                       | 
| ------------ | ------ | -------- | --------- | ----------------------------------------------------------------- | 
| StateChannel | PEA    | Input    | Bool      | OperationMode selection. 0: operator (..Op), 1: automatic (..Aut) | 
| StateOffAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Offline' in automatic mode              | 
| StateOpAut   | PEA    | Input    | Bool      | Switch Operation Mode to 'Operator' in automatic mode             | 
| StateAutAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Automatic' in automatic mode            | 
| StateOffOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Off' by operator                        | 
| StateOpOp    | POL    | Local    | Bool      | Switch Operation Mode to 'Operator' by operator                   | 
| StateAutOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Automatic' by operator                  | 
| StateOpAct   | PEA    | Output   | Bool      | Operator state active                                             | 
| StateAutAct  | PEA    | Output   | Bool      | Automatic state active                                            | 
| StateOffAct  | PEA    | Output   | Bool      | Offline state active                                              | 

### SourceMode

| Variable   | Source | Var Type | Data Type | Description                                                    | 
| ---------- | ------ | -------- | --------- | -------------------------------------------------------------- | 
| SrcChannel | PEA    | Input    | Bool      | SourceMode selection. 0: operator (..Op), 1: automatic (..Aut) | 
| SrcManAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Manual' in automatic mode               | 
| SrcIntAut  | PEA    | Input    | Bool      | Switch Source Mode to 'Internal' in automatic mode             | 
| SrcIntOp   | POL    | Local    | Bool      | Switch Source Mode to 'Internal' by operator                   | 
| SrcManOp   | POL    | Local    | Bool      | Switch Source Mode to 'Manual' by operator                     | 
| SrcIntAct  | PEA    | Output   | Bool      | Internal mode active                                           | 
| SrcManAct  | PEA    | Output   | Bool      | Manual mode active                                             | 

### Interlock

| Variable  | Source | Var Type | Data Type | Description                                                                   | 
| --------- | ------ | -------- | --------- | ----------------------------------------------------------------------------- | 
| PermEn    | PEA    | Input    | Bool      | Enables the Permission Lock. 1 = enabled (info for HMI)                       | 
| Permit    | PEA    | Input    | Bool      | Permit, allows control. Does not activate safe position. 1 = permission given | 
| IntlEn    | PEA    | Input    | Bool      | Enables the Interlock Lock. 1 = enabled (info for HMI)                        | 
| Interlock | PEA    | Input    | Bool      | Interlock, sets safe position. 0 = interlock active                           | 
| ProtEn    | PEA    | Input    | Bool      | Enables the Protection Lock. 1 = enabled (info for HMI)                       | 
| Protect   | PEA    | Input    | Bool      | Protect, sets safe position, sets protectState. 0 = Protect active            | 

### Specific

| Variable     | Source | Var Type | Data Type | Description                                                         | 
| ------------ | ------ | -------- | --------- | ------------------------------------------------------------------- | 
| WQC          | PEA    | Input    | Byte      | Worst Quality Code Variable                                         | 
| OSLevel      | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL    | 
| SafePos      | PEA    | Input    | Bool      | Safe Position. 0: posMin, 1: posMax                                 | 
| SafePosEn    | PEA    | Input    | Bool      | Safe Position Enable. 1: has safe position, 0: has no safe position | 
| SafePosAct   | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                               | 
| OpenAut      | PEA    | Input    | Bool      | Open command from controller program                                | 
| CloseAut     | PEA    | Input    | Bool      | Close command from controller program                               | 
| OpenOp       | POL    | Local    | Bool      | Open command by operator                                            | 
| CloseOp      | POL    | Local    | Bool      | Close command by operator                                           | 
| OpenAct      | PEA    | Output   | Bool      | Valve is set to Open                                                | 
| CloseAct     | PEA    | Output   | Bool      | Valve is set to Close                                               | 
| PosSclMin    | PEA    | Input    | Real      | Position Setpoint Scale Low Limit                                   | 
| PosSclMax    | PEA    | Input    | Real      | Position Setpoint Scale High Limit                                  | 
| PosUnit      | PEA    | Input    | Int       | Position Setpoint Unit                                              | 
| PosMin       | PEA    | Input    | Real      | Position Setpoint Low Limit                                         | 
| PosMax       | PEA    | Input    | Real      | Position Setpoint High Limit                                        | 
| PosInt       | PEA    | Input    | Real      | Position Internal Setpoint                                          | 
| PosMan       | POL    | Local    | Real      | Position Manual Setpoint                                            | 
| PosRbk       | PEA    | Local    | Real      | Position Readback Signal                                            | 
| Pos          | PEA    | Output   | Real      | Position Setpoint                                                   | 
| OpenFbkCalc  | PEA    | Input    | Bool      | Open Feedback Source. 0: sensor, 1: calculated                      | 
| OpenFbk      | PEA    | Input    | Bool      | Open Feedback Signal                                                | 
| CloseFbkCalc | PEA    | Input    | Bool      | Close Feedback Source. 0: sensor, 1: calculated                     | 
| CloseFbk     | PEA    | Input    | Bool      | Close Feedback Signal                                               | 
| PosFbkCalc   | PEA    | Input    | Bool      | Position Feedback Source. 0: sensor, 1: calculated                  | 
| PosFbk       | PEA    | Input    | Real      | Position Feedback Signal                                            | 
| ResetOp      | POL    | Local    | Bool      | Reset command by operator                                           | 
| ResetAut     | POL    | Input    | Bool      | Reset command from controller program                               | 
|              |        |          |           |                                                                     | 

TODO: PosSclMin: Limit = range?
TODO: Pos: raw value?
