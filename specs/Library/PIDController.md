# PID Controller

## MTP Interface

[AnaMon](./../MTP/PIDCtrl.md)

## Variable Table

| Variable            | MTP | SCD | Var Type | Data Type | Description                    | SCD Name | SCD Terminal Name |
| ------------------- | --- | --- | -------- | --------- | ------------------------------ | -------- | ----------------- |
| MTPBase             | x   |     | InOut    | PIDCtrl   |                                |          |                   |
| rawValue            | x   |     | Input    | Word      | Raw Input Value                |          |                   |
| valueUnit           | x   |     | Input    | Int       | Value Unit                     |          |                   |
| scaleMin            | x   |     | Input    | Real      | Scale Min Limit                |          |                   |
| scaleMax            | x   |     | Input    | Real      | Scale Max Limit                |          |                   |
| alarmHigh           | x   |     | Input    | Real      | Limit Value for Alarm High     |          |                   |
| warningHigh         | x   |     | Input    | Real      | Limit Value for Warning High   |          |                   |
| toleranceHigh       | x   |     | Input    | Real      | Limit Value for Tolerance High |          |                   |
| toleranceLow        | x   |     | Input    | Real      | Limit Value for Tolerance Low  |          |                   |
| warningLow          | x   |     | Input    | Real      | Limit Value for Warning Low    |          |                   |
| alarmLow            | x   |     | Input    | Real      | Limit Value for Alarm Low      |          |                   |
| alarmHighEn         | x   |     | Input    | Bool      | Alarm High Limit Enabled       |          |                   |
| warningHighEn       | x   |     | Input    | Bool      | Warning High Limit Enabled     |          |                   |
| toleranceHighEn     | x   |     | Input    | Bool      | Tolerance High Limit Enabled   |          |                   |
| toleranceLowEn      | x   |     | Input    | Bool      | Tolerance Low Limit Enabled    |          |                   |
| warningLowEn        | x   |     | Input    | Bool      | Warning Low Limit Enabled      |          |                   |
| alarmLowEn          | x   |     | Input    | Bool      | Alarm Low Limit Enabled        |          |                   |
| deadband            | x   |     | Input    | Real      | Deadband for alarms/warnings   |          |                   |
| externalFault       | x   |     | Input    | Bool      | Fault indication from outside  |          |                   |
| vOut                | x   |     | Output   | Real      | Value                          |          |                   |
| error               | x   |     | Output   | Bool      | Any error active               |          |                   |
| alarmHighStatus     | x   |     | Output   | Bool      | Alarm High Limit Active        |          |                   |
| warningHighStatus   | x   |     | Output   | Bool      | Warning High Limit Active      |          |                   |
| toleranceHighStatus | x   |     | Output   | Bool      | Tolerance High Limit Active    |          |                   |
| toleranceLowStatus  | x   |     | Output   | Bool      | Tolerance Low Limit Active     |          |                   |
| warningLowStatus    | x   |     | Output   | Bool      | Warning Low Limit Active       |          |                   |
| alarmLowStatus      | x   |     | Output   | Bool      | Alarm Low Limit Active         |          |                   |


