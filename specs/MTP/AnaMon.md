# AnaMon

## Variable Table

| Variable | Source | Var Type | Data Type | Description                                                      |
| -------- | ------ | -------- | --------- | ---------------------------------------------------------------- |
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                      |
| OSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL |
| V        | PEA    | Input    | Real      | Value                                                            |
| VSclMin  | PEA    | Input    | Real      | Value Scale Low Limit                                            |
| VSclMax  | PEA    | Input    | Real      | Value Scale High Limit                                           |
| VUnit    | PEA    | Input    | Int       | Value Unit                                                       |
| VAHEn    | PEA    | Input    | Bool      | 1: Alarm High Limit Enabled                                      |
| VWHEn    | PEA    | Input    | Bool      | 1: Warning High Limit Enabled                                    |
| VTHEn    | PEA    | Input    | Bool      | 1: Tolerance High Limit Enabled                                  |
| VTLEn    | PEA    | Input    | Bool      | 1: Tolerance Low Limit Enabled                                   |
| VWLEn    | PEA    | Input    | Bool      | 1: Warning Low Limit Enabled                                     |
| VALEn    | PEA    | Input    | Bool      | 1: Alarm Low Limit Enabled                                       |
| VAHLim   | POL    | Local    | Real      | Limit Value for Alarm High                                       |
| VWHLim   | POL    | Local    | Real      | Limit Value for Warning High                                     |
| VTHLim   | POL    | Local    | Real      | Limit Value for Tolerance High                                   |
| VTLLim   | POL    | Local    | Real      | Limit Value for Tolerance Low                                    |
| VWLLim   | POL    | Local    | Real      | Limit Value for Warning Low                                      |
| VALLim   | POL    | Local    | Real      | Limit Value for Alarm Low                                        |
| VAHAct   | PEA    | Output   | Bool      | 1: Alarm High Limit Active                                       |
| VWHAct   | PEA    | Output   | Bool      | 1: Warning High Limit Active                                     |
| VTHAct   | PEA    | Output   | Bool      | 1: Tolerance High Limit Active                                   |
| VTLAct   | PEA    | Output   | Bool      | 1: Tolerance Low Limit Active                                    |
| VWLAct   | PEA    | Output   | Bool      | 1: Warning Low Limit Active                                      |
| VALAct   | PEA    | Output   | Bool      | 1: Alarm Low Limit Active                                        |

## Functionality

| Target        | MTP | Expression                                                    | Comment                   |
| ------------- | --- | ------------------------------------------------------------- | ------------------------- |
| VAHAct        | x   | vOut >= alarmHigh                                             |                           |
| VWHAct        | x   | vOut >= warningHigh                                           |                           |
| VTHAct        | x   | vOut >= toleranceHigh                                         |                           |
| VTLAct        | x   | vOut <= toleranceLow                                          |                           |
| VWLAct        | x   | vOut <= warningLow                                            |                           |
| VALAct        | x   | vOut <= alarmLow                                              |                           |
