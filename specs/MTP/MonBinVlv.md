# MonBinVlv

## Variable Tables

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

| Variable     | Source | Var Type | Data Type | Description                                                               | Functionality      |
| ------------ | ------ | -------- | --------- | ------------------------------------------------------------------------- | ------------------ |
| WQC          | PEA    | Input    | Byte      | Worst Quality Code Variable                                               | TODO               |
| safePos      | PEA    | Input    | Bool      | Safe Position. 0: close, 1: open                                          | from Input         |
| safePosEn    | PEA    | Input    | Bool      | Safe Position Enable. 0: has safe position, 1: hold position on interlock | from Input         | TODO: what if command changes during interlock? Also 0 has different meaning than on MonAnaVlv?
| safePosAct   | PEA    | Output   | Bool      | Safe Position Activated. 1: activated                                     | from Epression (4) |
| openAut      | PEA    | Input    | Bool      | Open command from controller program                                      | from Input         |
| closeAut     | PEA    | Input    | Bool      | Close command from controller program                                     | from Input         |
| ctrl         | PEA    | Output   | Bool      | Control command to hardware                                               | from set/reset (3) | 
| openFbkCalc  | PEA    | Input    | Bool      | Open feedback is Calculated                                               | from Input         |
| openFbk      | PEA    | Input    | Bool      | Open feedback from the hardware                                           | from Input         |
| closeFbkCalc | PEA    | Input    | Bool      | Close feedback is calculated                                              | from Input         |
| closeFbk     | PEA    | Input    | Bool      | Close feedback from the hardware                                          | from Input         |
| resetAut     | PEA    | Input    | Bool      | Reset command from controller program                                     | from Input         | TODO: should this not be two signals? Which one should we add? see protectState, but that might be wrong
| monSafePos   | PEA    | Input    | Bool      | Behaviour if monitoring error. 1 = safe pos, 0 = hold pos                 | from Input         |
| monStatErr   | PEA    | Output   | Bool      | Static monitoring error occurred                                          | TODO               |
| monDynErr    | PEA    | Output   | Bool      | Dynamic Monitoring error occurred                                         | TODO               |
| monStatTi    | PEA    | Input    | Real      | monitor time for static changes, in s                                     | from Input         |
| monDynTi     | PEA    | Input    | Real      | monitor time for dynamic changes, in s                                    | from Input         |
| oSLevel      | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL          | TODO               | TODO: how can the controller know who is giving commands? would the tags not be the same?
| openOp       | POL    | Local    | Bool      | Open command by operator                                                  | from HMI + (2)     |
| closeOp      | POL    | Local    | Bool      | Close command by operator                                                 | from HMI + (2)     |
| resetOp      | POL    | Local    | Bool      | Reset command by operator                                                 | from HMI + (2)     |
| monEn        | POL    | Local    | Bool      | Monitor Enable. 1: enabled                                                | from HMI           | TODO: better output? 
| protectState |        | Output   | Bool      | Protect state, set by 'protect'. Needs reset. 0 = active                  | from set/reset (5) | TODO: rename to protectActive
| simulate     |        | Input    | Bool      | Enable simulation                                                         | from Input         | TODO: maybe activate openFbkCalc and closeFbkCalc if simulate is active? Or just add a simulateEn signal?
| error        |        | Output   | Bool      | Any error active                                                          | TODO               |
| opened       |        | Output   | Bool      | Valve is opened                                                           | TODO               |
| closed       |        | Output   | Bool      | Valve is closed                                                           | TODO               |

## Functionality

### (1) OperationMode State Machine

State Offline
- stateOffAct = 1
- stateOpAct = 0
- stateAutAct = 0
- stateOffOp = 0 // reset the HMI command

    Transition to Operator: (stateOpAut AND stateChannel) OR (stateOpOp AND NOT stateChannel)

State Operator
- stateOffAct = 0
- stateOpAct = 1
- stateAutAct = 0
- stateOpOp = 0 // reset the HMI command

    Transition to Offline: (stateOffAut AND stateChannel) OR (stateOffOp AND NOT stateChannel)
    Transition to Automatic:(StateAutAut AND stateChannel) OR (StateAutOp AND NOT stateChannel)

State Automatic
- stateOffAct = 0
- stateOpAct = 0
- stateAutAct = 1
- stateAutOp = 0 // reset the HMI command

    Transition to Operator: (stateOpAut AND stateChannel) OR (stateOpOp AND NOT stateChannel)

### (2) Reset all HMI commands at end of function block

- stateOffOp
- stateOpOp
- stateAutOp
- openOp
- closeOp
- resetOp

### (3) ctrl State

Set: (stateChannel AND openAut) OR (NOT stateChannel AND openOp) // todo: add interlock
Reset: (stateChannel AND closeAut) OR (NOT stateChannel AND closeOp) // todo: add interlock

### (4) safePosAct Expression

safePosAct = NOT interlock OR NOT protectState

### (5) protectState State

Set: protect
Reset: resetOp OR resetAut // TODO: need to check stateChannel? Normally reset by operator can always happen. Maybe check for aut?