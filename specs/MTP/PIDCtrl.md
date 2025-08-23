# PIDCtrl

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


### Specific

| Variable | Source | Var Type | Data Type | Description                                                      | 
| -------- | ------ | -------- | --------- | ---------------------------------------------------------------- | 
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | 
| OSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | 
| PV       | POL    | Input    | Real      | Process Value                                                    | 
| PVSclMin | POL    | Input    | Real      | Process Value Scale Low Limit                                    | 
| PVSclMax | POL    | Input    | Real      | Process Value Scale High Limit                                   | 
| PVUnit   | POL    | Input    | Int       | Process Value Unit                                               | 
| SPMan    | POL    | Local    | Real      | Manual Setpoint                                                  | 
| SPInt    | POL    | Input    | Real      | Internal Setpoint                                                | 
| SPSclMin | POL    | Input    | Real      | Setpoint Scale Low Limit                                         | 
| SPSclMax | POL    | Input    | Real      | Setpoint Scale High Limit                                        | 
| SPUnit   | POL    | Input    | Int       | Setpoint Unit                                                    | 
| SPIntMin | POL    | Input    | Real      | Internal Setpoint Low Limit                                      | 
| SPIntMax | POL    | Input    | Real      | Internal Setpoint High Limit                                     | 
| SPManMin | POL    | Input    | Real      | Manual Setpoint Low Limit                                        | 
| SPManMax | POL    | Input    | Real      | Manual Setpoint High Limit                                       | 
| SP       | POL    | Output   | Real      | Setpoint                                                         | 
| MVMan    | POL    | Local    | Real      | Manipulated Value from Operator                                  | 
| MV       | POL    | Output   | Real      | Manipulated Value                                                | 
| MVMin    | POL    | Input    | Real      | Minimal Manipulated Value                                        | 
| MVMax    | POL    | Input    | Real      | Maximal Manipulated Value                                        | 
| MVUnit   | POL    | Input    | Int       | Manipulated Value Unit                                           | 
| MVSclMin | POL    | Input    | Real      | Manipulated Value Scale Low Limit                                | 
| MVSclMax | POL    | Input    | Real      | Manipulated Value Scale High Limit                               | 
| P        | POL    | Input    | Real      | Proportional Parameter                                           | 
| Ti       | POL    | Input    | Real      | Integration Parameter in s                                       | 
| Td       | POL    | Input    | Real      | Derivation Parameter in s                                        | 
|          |        |          |           |                                                                  |               
|          |        |          |           |                                                                  |               
