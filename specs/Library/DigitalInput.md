# Digital Input

## MTP Interface

[AnaMon](./../MTP/BinMon.md)

## Variable Table

| Variable    | MTP | SCD | Var Type | Data Type | Description                               | SCD Name | SCD Terminal Name |
| ----------- | --- | --- | -------- | --------- | ----------------------------------------- | -------- | ----------------- |
| MTPBase     | x   | x   | InOut    | BinMon    |                                           |          |                   |
| value       | x   |     | Input    | Bool      | Value coming from device                  |          |                   |
| valueOut    | x   |     | Output   | Bool      | Value for use in program                  |          |                   |
| risingEdge  | x   |     | Output   | Bool      | Input value transitioned from low to high |          |                   |
| fallingEdge | x   |     | Output   | Bool      | Input value transitioned from high to low |          |                   |

