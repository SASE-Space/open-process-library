# Digital Input

## MTP Interface

[BinMon](./../MTP/BinMon.md)

## Variable Table

| Variable    | MTP | SCD | Var Type | Data Type | Default | Description                               | SCD Name | SCD Terminal Name |
| ----------- | --- | --- | -------- | --------- | ------- | ----------------------------------------- | -------- | ----------------- |
| MTPBase     | x   | x   | InOut    | BinMon    |         |                                           |          |                   |
| value       | x   |     | Input    | Bool      |         | Value coming from device                  |          |                   |
| valueOut    | x   |     | Output   | Bool      |         | Value for use in program                  |          |                   |
| risingEdge  | x   |     | Output   | Bool      |         | Input value transitioned from low to high |          |                   |
| fallingEdge | x   |     | Output   | Bool      |         | Input value transitioned from high to low |          |                   |
| lastValue   | x   |     | Local    | Bool      |         | Value from last scan, for edge detection  |          |                   |



## Functionality

| Target      | MTP signal | MTP | SCD | Expression                           | Comment                                         |
| ----------- | ---------- | --- | --- | ------------------------------------ | ----------------------------------------------- |
| WQC         | x          | x   |     | 16#FF                                | no QC available (default)                       |
| OSLevel     |            | x   |     | TODO                                 |                                                 |
| V           | x          | x   |     | value                                |                                                 |
| VState0     | x          | x   |     | "False"                              | TODO: hardcoded for now                         |
| VState1     | x          | x   |     | "True"                               | TODO: hardcoded for now                         |
| VFlutEn     | x          | x   |     | False                                | TODO: hardcoded for now                         |
| risingEdge  |            | x   |     | value != lastValue and value = True  |                                                 |
| fallingEdge |            | x   |     | value != lastValue and value = Valse |                                                 |
| lastValue   |            | x   |     | value                                | copy value to lastValue at the end of the block |
|             |            |     |     |                                      |                                                 |