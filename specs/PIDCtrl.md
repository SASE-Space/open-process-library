# PIDCtrl

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


### Specific

| Variable | Source | Var Type | Data Type | Description                                                      | Functionality |
| -------- | ------ | -------- | --------- | ---------------------------------------------------------------- | ------------- |
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | TODO          |
| oSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | TODO          |
| pV       | POL    | Input    | Real      | Process Value                                                    | TODO          |
| pVSclMin | POL    | Input    | Real      | Process Value Scale Low Limit                                    | TODO          |
| pVSclMax | POL    | Input    | Real      | Process Value Scale High Limit                                   | TODO          |
| pVUnit   | POL    | Input    | Int       | Process Value Unit                                               | TODO          |
| sPMan    | POL    | Local    | Real      | Manual Setpoint                                                  | TODO          |
| sPInt    | POL    | Input    | Real      | Internal Setpoint                                                | TODO          |
| sPSclMin | POL    | Input    | Real      | Setpoint Scale Low Limit                                         | TODO          |
| sPSclMax | POL    | Input    | Real      | Setpoint Scale High Limit                                        | TODO          |
| sPUnit   | POL    | Input    | Int       | Setpoint Unit                                                    | TODO          |
| sPIntMin | POL    | Input    | Real      | Internal Setpoint Low Limit                                      | TODO          |
| sPIntMax | POL    | Input    | Real      | Internal Setpoint High Limit                                     | TODO          |
| sPManMin | POL    | Input    | Real      | Manual Setpoint Low Limit                                        | TODO          |
| sPManMax | POL    | Input    | Real      | Manual Setpoint High Limit                                       | TODO          |
| sP       | POL    | Output   | Real      | Setpoint                                                         | TODO          |
| mVMan    | POL    | Local    | Real      | Manipulated Value from Operator                                  | TODO          |
| mV       | POL    | Output   | Real      | Manipulated Value                                                | TODO          |
| mVMin    | POL    | Input    | Real      | Minimal Manipulated Value                                        | TODO          |
| mVMax    | POL    | Input    | Real      | Maximal Manipulated Value                                        | TODO          |
| mVUnit   | POL    | Input    | Int       | Manipulated Value Unit                                           | TODO          |
| mVSclMin | POL    | Input    | Real      | Manipulated Value Scale Low Limit                                | TODO          |
| mVSclMax | POL    | Input    | Real      | Manipulated Value Scale High Limit                               | TODO          |
| p        | POL    | Input    | Real      | Proportional Parameter                                           | TODO          |
| ti       | POL    | Input    | Real      | Integration Parameter in s                                       | TODO          |
| td       | POL    | Input    | Real      | Derivation Parameter in s                                        | TODO          |
|          |        |          |           |                                                                  |               |
|          |        |          |           |                                                                  |               |
