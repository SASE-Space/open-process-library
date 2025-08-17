# PID Controller

## MTP Interface

[PIDCtrl](./../MTP/PIDCtrl.md)

## Variable Table

| Variable             | MTP | SCD | Var Type | Data Type | Default | Description                        | SCD Name | SCD Terminal Name |
| -------------------- | --- | --- | -------- | --------- | ------- | ---------------------------------- | -------- | ----------------- |
| MTPBase              | x   |     | InOut    | PIDCtrl   |         |                                    |          |                   |
| setpoint             |     |     | Input    | Real      |         | Setpoint from program              |          |                   |
| rawValue             | x   |     | Input    | Word      |         | Raw Input Value                    |          |                   |
| valueUnit            | x   |     | Input    | Int       |         | Value Unit                         |          |                   |
| manipulatedValueUnit | x   |     | Input    | Int       |         |                                    |          |                   |
| scaleMin             | x   |     | Input    | Real      |         | Scale Min for read value           |          |                   |
| scaleMax             | x   |     | Input    | Real      |         | Scale Max for read value           |          |                   |
| scaleMinMV           | x   |     | Input    | Real      |         | Scale Min for Manipulated Value    |          |                   |
| scaleMaxMV           | x   |     | Input    | Real      |         | Scale Max for Manipulated Value    |          |                   |
| proportional         | x   |     | Input    | Real      |         | Proportional Parameter             |          |                   |
| integration          | x   |     | Input    | Real      |         | Integration Parameter in s         |          |                   |
| derivation           | x   |     | Input    | Real      |         | Derivation Parameter in s          |          |                   |
| alarmHigh            | x   |     | Input    | Real      |         | Limit Value for Alarm High         |          |                   |
| warningHigh          | x   |     | Input    | Real      |         | Limit Value for Warning High       |          |                   |
| toleranceHigh        | x   |     | Input    | Real      |         | Limit Value for Tolerance High     |          |                   |
| toleranceLow         | x   |     | Input    | Real      |         | Limit Value for Tolerance Low      |          |                   |
| warningLow           | x   |     | Input    | Real      |         | Limit Value for Warning Low        |          |                   |
| alarmLow             | x   |     | Input    | Real      |         | Limit Value for Alarm Low          |          |                   |
| alarmHighEn          | x   |     | Input    | Bool      |         | Alarm High Limit Enabled           |          |                   |
| warningHighEn        | x   |     | Input    | Bool      |         | Warning High Limit Enabled         |          |                   |
| toleranceHighEn      | x   |     | Input    | Bool      |         | Tolerance High Limit Enabled       |          |                   |
| toleranceLowEn       | x   |     | Input    | Bool      |         | Tolerance Low Limit Enabled        |          |                   |
| warningLowEn         | x   |     | Input    | Bool      |         | Warning Low Limit Enabled          |          |                   |
| alarmLowEn           | x   |     | Input    | Bool      |         | Alarm Low Limit Enabled            |          |                   |
| deadband             | x   |     | Input    | Real      |         | Deadband for alarms/warnings       |          |                   |
| externalFault        | x   |     | Input    | Bool      |         | Fault indication from outside      |          |                   |
| setpointOut          | x   |     | Output   | Real      |         | Active setpoint                    |          |                   |
| valueOut             | x   |     | Output   | Real      |         | input Value for use in the program |          |                   |
| manipulatedValue     | x   |     | Output   | Real      |         | manipulated value                  |          |                   |
| error                | x   |     | Output   | Bool      |         | Any error active                   |          |                   |
| alarmHighStatus      | x   |     | Output   | Bool      |         | Alarm High Limit Active            |          |                   |
| warningHighStatus    | x   |     | Output   | Bool      |         | Warning High Limit Active          |          |                   |
| toleranceHighStatus  | x   |     | Output   | Bool      |         | Tolerance High Limit Active        |          |                   |
| toleranceLowStatus   | x   |     | Output   | Bool      |         | Tolerance Low Limit Active         |          |                   |
| warningLowStatus     | x   |     | Output   | Bool      |         | Warning Low Limit Active           |          |                   |
| alarmLowStatus       | x   |     | Output   | Bool      |         | Alarm Low Limit Active             |          |                   |
|                      |     |     |          |           |         |                                    |          |                   |


## Functionality

| Target            | MTP signal | MTP | SCD | Expression                                                    | Comment                          |
| ----------------- | ---------- | --- | --- | ------------------------------------------------------------- | -------------------------------- |
| WQC               | x          | x   |     | 16#FF                                                         | no QC available (default)        |
| OSLevel           | x          | x   |     | TODO                                                          |                                  |
| remote            |            | x   |     | StateChannel                                                  |                                  |
| operator          |            | x   |     | StateOpAct                                                    |                                  |
| automatic         |            | x   |     | StateAutAct                                                   |                                  |
| offline           |            | x   |     | StateOffAct                                                   |                                  |
| remoteSource      |            | x   |     | SrcChannel                                                    |                                  |
| internalSourceAct |            | x   |     | SrcIntAct                                                     |                                  |
| manualSourceAct   |            | x   |     | SrcManAct                                                     |                                  |
| PV                | x          | x   |     | scaleMin + (REAL(rawValue) / 27648.0) * (scaleMax - scaleMin) |                                  |
| valueOut          |            | x   |     | PV                                                            |                                  |
| PVSclMin          | x          | x   |     | scaleMin                                                      |                                  |
| PVSclMax          | x          | x   |     | scaleMax                                                      |                                  |
| PVUnit            | x          | x   |     | valueUnit                                                     |                                  |
| SPInt             | x          | x   |     | setpoint                                                      |                                  |
| SPSclMin          | x          | x   |     | scaleMin                                                      | SP and PV should have same scale |
| SPSclMax          | x          | x   |     | scaleMax                                                      | SP and PV should have same scale |
| SPUnit            | x          | x   |     | valueUnit                                                     | SP and PV should have same unit  |
| SPIntMin          | x          | x   |     | scaleMin                                                      | no limits for now                |
| SPIntMax          | x          | x   |     | scaleMax                                                      | no limits for now                |
| SPManMin          | x          | x   |     | scaleMin                                                      | no limits for now                |
| SPManMax          | x          | x   |     | scaleMax                                                      | no limits for now                |
| setpointOut       |            | x   |     | SP                                                            |                                  |
| manipulatedValue  |            | x   |     | MV                                                            |                                  |
| MVMin             | x          | x   |     | scaleMinMV                                                    |                                  |
| MVMax             | x          | x   |     | scaleMaxMV                                                    |                                  |
| MVUnit            | x          | x   |     | manipulatedValueUnit                                          |                                  |
| MVSclMin          | x          | x   |     | scaleMinMV                                                    |                                  |
| MVSclMax          | x          | x   |     | scaleMaxMV                                                    |                                  |
| proportional      |            | x   |     | P                                                             |                                  |
| integration       |            | x   |     | Ti                                                            |                                  |
| derivation        |            | x   |     | Td                                                            |                                  |
|                   |            |     |     |                                                               |                                  |

