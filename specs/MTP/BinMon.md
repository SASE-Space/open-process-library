# BinMon

## Variable Table

| Variable | Source | Var Type | Data Type | Description                                                           | Functionality |
| -------- | ------ | -------- | --------- | --------------------------------------------------------------------- | ------------- |
| wQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                           | TODO          |
| v        | PEA    | Input    | Bool      | Value                                                                 |               | TODO: is this the value before or after defluttering? Probably need to add an extra input or output. Probably before
| vState0  | PEA    | Input    | String    | Text value for False                                                  |               |
| vState1  | PEA    | Input    | String    | Text value for True                                                   |               |
| oSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL      | TODO          |
| vFlutEn  | PEA    | Input    | Bool      | Enable Fluttering Recognition                                         |               |
| vFlutTi  | POL    | Local    | Real      | Period of active signal before it is flutter-free, in s               |               | TODO: changes in the new MTP version about how fluttering is handled?
| vFlutCnt | POL    | Local    | Int       | Counts of the allowed flutering signals in the defined period vFlutTi |               |
| vFlutAct | PEA    | Output   | Bool      | Fluttering Signal recognized                                          |               |
|          |        |          |           |                                                                       |               |
|          |        |          |           |                                                                       |               |


