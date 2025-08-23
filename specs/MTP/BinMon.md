# BinMon

## Variable Table

| Variable | Source | Var Type | Data Type | Description                                                           | 
| -------- | ------ | -------- | --------- | --------------------------------------------------------------------- | 
| WQC      | PEA    | Input    | Byte      | Worst Quality Code Variable                                           | 
| V        | PEA    | Input    | Bool      | Value                                                                 |               
| VState0  | PEA    | Input    | String    | Text value for False                                                  |               
| VState1  | PEA    | Input    | String    | Text value for True                                                   |               
| OSLevel  | POL    | Input    | Byte      | manual operation permission. 0 = only on-site. >0: only from POL      |           
| VFlutEn  | PEA    | Input    | Bool      | Enable Fluttering Recognition                                         |               
| VFlutTi  | POL    | Local    | Real      | Period of active signal before it is flutter-free, in s               |                
| VFlutCnt | POL    | Local    | Int       | Counts of the allowed flutering signals in the defined period vFlutTi |               
| VFlutAct | PEA    | Output   | Bool      | Fluttering Signal recognized                                          |               
|          |        |          |           |                                                                       |               
|          |        |          |           |                                                                       |               

TODO: V: is this the value before or after defluttering? Probably need to add an extra input or output. Probably before
TODO: VFlutTi: changes in the new MTP version about how fluttering is handled?