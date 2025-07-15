# AnaMon

## Variable Table

| Variable | Source | Var Type | Data Type | Description                                                      | Functionality |
| -------- | ------ | -------- | --------- | ---------------------------------------------------------------- | ------------- |
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                      | TODO          |
| v        | PEA    | Input    | Real      | Value                                                            | TODO          | TODO: move to Output because rawValue will be connected to the hardware
| vSclMin  | PEA    | Input    | Real      | Value Scale Low Limit                                            | TODO          |
| vSclMax  | PEA    | Input    | Real      | Value Scale High Limit                                           | TODO          |
| vUnit    | PEA    | Input    | Int       | Value Unit                                                       | TODO          |
| oSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL | TODO          |
| vAHEn    | PEA    | Input    | Bool      | 1: Alarm High Limit Enabled                                      | TODO          |
| vWHEn    | PEA    | Input    | Bool      | 1: Warning High Limit Enabled                                    | TODO          |
| vTHEn    | PEA    | Input    | Bool      | 1: Tolerance High Limit Enabled                                  | TODO          |
| vTLEn    | PEA    | Input    | Bool      | 1: Tolerance Low Limit Enabled                                   | TODO          |
| vWLEn    | PEA    | Input    | Bool      | 1: Warning Low Limit Enabled                                     | TODO          |
| vALEn    | PEA    | Input    | Bool      | 1: Alarm Low Limit Enabled                                       | TODO          |
| vAHLim   | POL    | Local    | Real      | Limit Value for Alarm High                                       | TODO          | TODO: change to Input?
| vWHLim   | POL    | Local    | Real      | Limit Value for Warning High                                     | TODO          |
| vTHLim   | POL    | Local    | Real      | Limit Value for Tolerance High                                   | TODO          |
| vTLLim   | POL    | Local    | Real      | Limit Value for Tolerance Low                                    | TODO          |
| vWLLim   | POL    | Local    | Real      | Limit Value for Warning Low                                      | TODO          |
| vALLim   | POL    | Local    | Real      | Limit Value for Alarm Low                                        | TODO          |
| vAHAct   | PEA    | Output   | Bool      | 1: Alarm High Limit Active                                       | TODO          |
| vWHAct   | PEA    | Output   | Bool      | 1: Warning High Limit Active                                     | TODO          |
| vTHAct   | PEA    | Output   | Bool      | 1: Tolerance High Limit Active                                   | TODO          |
| vTLAct   | PEA    | Output   | Bool      | 1: Tolerance Low Limit Active                                    | TODO          |
| vWLAct   | PEA    | Output   | Bool      | 1: Warning Low Limit Active                                      | TODO          |
| vALAct   | PEA    | Output   | Bool      | 1: Alarm Low Limit Active                                        | TODO          |
| rawValue |        | Input    | Word      |                                                                  | TODO          |
| deadband |        | Input    | Real      | Deadband for alarms/warnings                                     | TODO          | TODO: absolute value or %?
|          |        |          |           |                                                                  |               |
|          |        |          |           |                                                                  |               |

