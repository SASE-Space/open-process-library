# MonBinVlv


## Variable Tables

### Operation Mode

| Variable     | Source | Var Type | Data Type | Description                                            |
| ------------ | ------ | -------- | --------- | ------------------------------------------------------ |
| StateChannel | PEA    | Input    | Bool      | 0: operator/local, 1: automatic/remote                 |
| StateOffAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Offline' in automatic mode   |
| StateOpAut   | PEA    | Input    | Bool      | Switch Operation Mode to 'Operator' in automatic mode  |
| StateAutAut  | PEA    | Input    | Bool      | Switch Operation Mode to 'Automatic' in automatic mode |
| StateOffOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Off' by operator             |
| StateOpOp    | POL    | Local    | Bool      | Switch Operation Mode to 'Operator' by operator        |
| StateAutOp   | POL    | Local    | Bool      | Switch Operation Mode to 'Automatic' by operator       |
| StateOpAct   | PEA    | Output   | Bool      | Operator state active                                  |
| StateAutAct  | PEA    | Output   | Bool      | Automatic state active                                 |
| StateOffAct  | PEA    | Output   | Bool      | Offline state active                                   |

### Interlock

| Variable  | Source | Var Type | Data Type | Description                                                                |
| --------- | ------ | -------- | --------- | -------------------------------------------------------------------------- |
| PermEn    | PEA    | Input    | Bool      | Enables the Permission Lock. 1 = enabled (info for HMI)                    |
| IntlEn    | PEA    | Input    | Bool      | Enables the Interlock Lock. 1 = enabled (info for HMI)                     |
| ProtEn    | PEA    | Input    | Bool      | Enables the Protection Lock. 1 = enabled (info for HMI)                    |
| Permit    | PEA    | Input    | Bool      | Permit, allows control. Does not activate safe position. 0 = no permission |
| Interlock | PEA    | Input    | Bool      | Interlock, sets safe position. 0 = interlock active                        |
| Protect   | PEA    | Input    | Bool      | Protect, sets safe position, needs reset. 0 = Protect active               |

### Specific

| Variable      | Source | Var Type | Data Type | Default | Description                                                               |
| ------------- | ------ | -------- | --------- | ------- | ------------------------------------------------------------------------- |
| WQC           | PEA    | Input    | Byte      |         | Worst Quality Code Variable                                               |
| OSLevel       | POL    | Input    | Byte      |         | manual operation permission. 0 = only on-site. >0: only from POL          |  
| SafePos       | PEA    | Input    | Bool      |         | Safe Position. 0: close, 1: open                                          |
| SafePosEn     | PEA    | Input    | Bool      |         | Safe Position Enable. 0: has safe position, 1: hold position on interlock | 
| SafePosAct    | PEA    | Output   | Bool      |         | Safe Position Activated. 1: activated                                     |
| OpenAut       | PEA    | Input    | Bool      |         | Open command from controller program                                      |
| CloseAut      | PEA    | Input    | Bool      |         | Close command from controller program                                     |
| Ctrl          | PEA    | Output   | Bool      |         | Control command to hardware                                               |
| OpenFbkCalc   | PEA    | Input    | Bool      |         | Open feedback is Calculated                                               |
| CloseFbkCalc  | PEA    | Input    | Bool      |         | Close feedback is calculated                                              |
| OpenFbk       | PEA    | Input    | Bool      |         | Open feedback from the hardware                                           |
| CloseFbk      | PEA    | Input    | Bool      |         | Close feedback from the hardware                                          |
| MonSafePos    | PEA    | Input    | Bool      |         | Behaviour if monitoring error. 1 = safe pos, 0 = hold pos                 |
| MonStatErr    | PEA    | Output   | Bool      |         | Static monitoring error occurred                                          |
| MonDynErr     | PEA    | Output   | Bool      |         | Dynamic Monitoring error occurred                                         |
| MonStatTi     | PEA    | Input    | Real      | 5       | monitor time for static changes, in s                                     |
| MonDynTi      | PEA    | Input    | Real      | 2       | monitor time for dynamic changes, in s                                    |
| OpenOp        | POL    | Local    | Bool      |         | Open command by operator                                                  |
| CloseOp       | POL    | Local    | Bool      |         | Close command by operator                                                 |
| ResetAut      | PEA    | Input    | Bool      |         | Reset command from controller program                                     | 
| ResetOp       | POL    | Local    | Bool      |         | Reset command by operator                                                 |
| MonEn         | POL    | Local    | Bool      |         | Monitor Enable. 1: enabled                                                |  
| OperationMode |        | Output   | Int       |         | 0: Offline, 1: Operator, 2: Automatic                                     |  
| OpenedState   |        | Local    | Bool      |         | For tracking the static monitoring error                                  |
| ClosedState   |        | Local    | Bool      |         | For tracking the static monitoring error                                  |


## Functionality

| Target        | MTP | Expression                                                                       | Comment                         |
| ------------- | --- | -------------------------------------------------------------------------------- | ------------------------------- |
|               |     |                                                                                  |                                 |
|               |     | // State Machine for the OperationMode                                           |                                 |
| OperationMode |     | OperationMode State Machine                                                      |                                 |
|               |     |                                                                                  |                                 |
|               |     | // Make boolean indicators for the OperationMode State                           |                                 |
| StateOpAct    | x   | OperationMode = 1                                                                |                                 |
| StateAutAct   | x   | OperationMode = 2                                                                |                                 |
| StateOffAct   | x   | OperationMode = 0                                                                |                                 |
|               |     |                                                                                  |                                 |
|               |     | // 'Protect' is for interlocks that need to be reset                             |                                 |
| Protect       |     | Reset: (ResetAut AND StateChannel) OR (ResetOp AND NOT StateChannel)             |                                 |
|               |     |                                                                                  |                                 |
|               |     | // signal indicating that the valve needs to go to the safe position             |                                 |
| SafePosAct    | x   | (PermEn AND NOT Permit)                                                          |                                 |
|               |     | OR (IntlEn AND NOT Interlock)                                                    |                                 |
|               |     | OR (ProtEn AND NOT Protect)                                                      |                                 |
|               |     | OR (MonEn AND (MonStatErr OR MonDynErr))                                         |                                 |
|               |     |                                                                                  |                                 |
|               |     | // control signal to the hardware                                                |                                 |
| Ctrl          | x   | Set:                                                                             |                                 |
|               |     | (SafePosAct AND SafePos AND NOT SafePosEn)                                       | open valve on interlock         |
|               |     | OR (NOT SafePosAct AND ((OpenAut AND StateAutAct) OR (OpenOp and StateOpAct)))   | open command when no interlock  |
|               |     | Reset:                                                                           |                                 |
|               |     | (SafePosAct AND NOT SafePos AND NOT SafePosEn)                                   | close valve on interlock        |
|               |     | OR (NOT SafePosAct AND ((CloseAut AND StateAutAct) OR (CloseOp and StateOpAct))) | close command when no interlock |
|               |     |                                                                                  |                                 |
|               |     | // Opened and Closed States                                                      |                                 |
| OpenedState   |     | Set: Ctrl AND OpenFbk                                                            |                                 |
|               |     | Reset: NOT Ctrl                                                                  |                                 |
| ClosedState   |     | Set: NOT Ctrl AND CloseFbk                                                       |                                 |
|               |     | Reset: Ctrl                                                                      |                                 |
|               |     |                                                                                  |                                 |
|               |     | // Static and Dynamic Monitoring                                                 |                                 |
| MonStatErr    | x   | Set:                                                                             |                                 |
|               |     | (MonEn AND OpenedState AND NOT OpenFbk)                                          |                                 |
|               |     | OR ( MonEn AND ClosedState AND NOT CloseFbk) for MonStatTi                       |                                 |
|               |     | Reset: (ResetAut AND StateChannel) OR (ResetOp AND NOT StateChannel)             |                                 |
| MonDynErr     | x   | Set:                                                                             |                                 |
|               |     | MonEn AND ((Ctrl AND NOT OpenFbk) OR (NOT Ctrl AND NOT CloseFbk)) for MonDynTi   |                                 |
|               |     | Reset: (ResetAut AND StateChannel) OR (ResetOp AND NOT StateChannel)             |                                 |
|               |     |                                                                                  |                                 |
|               |     | // reset operator command                                                        |                                 |
| StateOffOp    | x   | False                                                                            | Reset at the end of the FB      |
| StateOpOp     | x   | False                                                                            | Reset at the end of the FB      |
| StateAutOp    | x   | False                                                                            | Reset at the end of the FB      |
| OpenOp        | x   | False                                                                            | Reset at the end of the FB      |
| CloseOp       | x   | False                                                                            | Reset at the end of the FB      |
| ResetOp       | x   | False                                                                            | Reset at the end of the FB      |
| StateOpAut    | x   | False                                                                            | Reset at the end of the FB      |
| StateAutAut   | x   | False                                                                            | Reset at the end of the FB      |
| StateOffAut   | x   | False                                                                            | Reset at the end of the FB      |
|               |     |                                                                                  |                                 |
|               |     |                                                                                  |                                 |


### OperationMode State Machine

| State         | Actions | Transition Condition                 | Target |
| ------------- | ------- | ------------------------------------ | ------ |
| 0 (Offline)   |         | (StateOpAut AND StateChannel)        |        |
|               |         | OR (StateOpOp AND NOT StateChannel)  | 1      |
|               |         |                                      |        |
| 1 (Operator)  |         | (StateOffAut AND StateChannel)       |        |
|               |         | OR (StateOffOp AND NOT StateChannel) | 0      |
|               |         |                                      |        |
|               |         | (StateAutAut AND StateChannel)       |        |
|               |         | OR (StateAutOp AND NOT StateChannel) | 2      |
|               |         |                                      |        |
| 2 (Automatic) |         | (StateOpAut AND StateChannel)        |        |
|               |         | OR (StateOpOp AND NOT StateChannel)  | 1      |
|               |         |                                      |        |



## TODO
- (1) OSLevel: how can the controller know who is giving commands? would the tags not be the same?
- (2) SafePosEn: what if command changes during interlock? Also 0 has different meaning than on MonAnaVlv?

