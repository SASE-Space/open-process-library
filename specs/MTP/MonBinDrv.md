# MonBinDrv

## Variable Tables

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

| Variable   | Source | Var Type | Data Type | Description                                                      | 
| ---------- | ------ | -------- | --------- | ---------------------------------------------------------------- | 
| WQC        | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | 
| OSLevel    | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | 
| SafePos    | PEA    | Input    | Bool      | Safe Position. 0: stop, 1: energize                              | 
| SafePosAct | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                            | 
| FwdEn      | PEA    | Input    | Bool      | Forward enable                                                   | 
| RevEn      | PEA    | Input    | Bool      | Reverse enable                                                   | 
| StopOp     | POL    | Local    | Bool      | Stop command by operator                                         | 
| FwdOp      | POL    | Local    | Bool      | Forward command by operator                                      | 
| RevOp      | POL    | Local    | Bool      | Reverse command by operator                                      | 
| StopAut    | PEA    | Input    | Bool      | Open command from controller program                             | 
| FwdAut     | PEA    | Input    | Bool      | Forward command from controller program                          | 
| RevAut     | PEA    | Input    | Bool      | Reverse command from controller program                          | 
| FwdCtrl    | PEA    | Output   | Bool      | Forward Control command to hardware                              | 
| RevCtrl    | PEA    | Output   | Bool      | Reverse Control command to hardware                              | 
| RevFbkCalc | PEA    | Input    | Bool      | Reverse feedback is Calculated                                   | 
| RevFbk     | PEA    | Input    | Bool      | Reverse feedback from the hardware                               | 
| FwdFbkCalc | PEA    | Input    | Bool      | Forward feedback is calculated                                   | 
| FwdFbk     | PEA    | Input    | Bool      | Forward feedback from the hardware                               | 
| Trip       | PEA    | Input    | Bool      | Drive Protection Indicator. 0: tripped, 1: no error              | 
| ResetOp    | POL    | Local    | Bool      | Reset command by operator                                        | 
| ResetAut   | PEA    | Input    | Bool      | Reset command from controller program                            | 
| MonEn      | POL    | Local    | Bool      | Monitor Enable. 1: enabled                                       | 
| MonSafePos | PEA    | Input    | Bool      | Behaviour if monitoring error. 1 = safe pos, 0 = hold pos        | 
| MonStatErr | PEA    | Output   | Bool      | Static monitoring error occurred                                 | 
| MonDynErr  | PEA    | Output   | Bool      | Dynamic Monitoring error occurred                                | 
| MonStatTi  | PEA    | Input    | Real      | monitor time for static changes, in s                            | 
| MonDynTi   | PEA    | Input    | Real      | monitor time for dynamic changes, in s                           | 


