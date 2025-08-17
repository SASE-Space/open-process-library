# PIDCtrl

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


### Specific

| Variable | Source | Var Type | Data Type | Description                                                      | Functionality |
| -------- | ------ | -------- | --------- | ---------------------------------------------------------------- | ------------- |
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | TODO          |
| OSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | TODO          |
| PV       | POL    | Input    | Real      | Process Value                                                    | TODO          |
| PVSclMin | POL    | Input    | Real      | Process Value Scale Low Limit                                    | TODO          |
| PVSclMax | POL    | Input    | Real      | Process Value Scale High Limit                                   | TODO          |
| PVUnit   | POL    | Input    | Int       | Process Value Unit                                               | TODO          |
| SPMan    | POL    | Local    | Real      | Manual Setpoint                                                  | TODO          |
| SPInt    | POL    | Input    | Real      | Internal Setpoint                                                | TODO          |
| SPSclMin | POL    | Input    | Real      | Setpoint Scale Low Limit                                         | TODO          |
| SPSclMax | POL    | Input    | Real      | Setpoint Scale High Limit                                        | TODO          |
| SPUnit   | POL    | Input    | Int       | Setpoint Unit                                                    | TODO          |
| SPIntMin | POL    | Input    | Real      | Internal Setpoint Low Limit                                      | TODO          |
| SPIntMax | POL    | Input    | Real      | Internal Setpoint High Limit                                     | TODO          |
| SPManMin | POL    | Input    | Real      | Manual Setpoint Low Limit                                        | TODO          |
| SPManMax | POL    | Input    | Real      | Manual Setpoint High Limit                                       | TODO          |
| SP       | POL    | Output   | Real      | Setpoint                                                         | TODO          |
| MVMan    | POL    | Local    | Real      | Manipulated Value from Operator                                  | TODO          |
| MV       | POL    | Output   | Real      | Manipulated Value                                                | TODO          |
| MVMin    | POL    | Input    | Real      | Minimal Manipulated Value                                        | TODO          |
| MVMax    | POL    | Input    | Real      | Maximal Manipulated Value                                        | TODO          |
| MVUnit   | POL    | Input    | Int       | Manipulated Value Unit                                           | TODO          |
| MVSclMin | POL    | Input    | Real      | Manipulated Value Scale Low Limit                                | TODO          |
| MVSclMax | POL    | Input    | Real      | Manipulated Value Scale High Limit                               | TODO          |
| P        | POL    | Input    | Real      | Proportional Parameter                                           | TODO          |
| Ti       | POL    | Input    | Real      | Integration Parameter in s                                       | TODO          |
| Td       | POL    | Input    | Real      | Derivation Parameter in s                                        | TODO          |
|          |        |          |           |                                                                  |               |
|          |        |          |           |                                                                  |               |
