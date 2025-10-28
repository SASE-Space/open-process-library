# PID Controller

## MTP Interface

[PIDCtrl](./../MTP/PIDCtrl.md)

## Variable Table

| Variable             | MTP | SCD | Var Type | Data Type | Default | Description                                                             | SCD Name | SCD Terminal Name |
| -------------------- | --- | --- | -------- | --------- | ------- | ----------------------------------------------------------------------- | -------- | ----------------- |
| MTPBase              | x   |     | InOut    | PIDCtrl   |         |                                                                         |          |                   |
| id                   | x   | x   | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects           |          |                   |
| activateManualSP     | x   |     | Input    | Bool      |         | Activates Fixed Manual Setpoint (Activation by Program)                 |          |                   |
| activateDynamicSP    | x   |     | Input    | Bool      |         | Activates Internal Dynamic Setpoint (Activation by Program)             |          |                   |
| activateFixedSP      | x   |     | Input    | Bool      |         | Activates Internal Fixed Setpoint (Activation by Program)               |          |                   |
| dynamicSP            | x   |     | Input    | Real      |         | Dynamic Setpoint from Program (for example from cascade PID controller) |          |                   |
| fixedSP              | x   |     | Input    | Real      |         | Fixed Setpoint from Program (for example from a Phase/Sequence control) |          |                   |
| rawValue             | x   |     | Input    | Word      |         | Raw Input Value                                                         |          |                   |
| valueUnit            | x   |     | Input    | Int       |         | Value Unit                                                              |          |                   |
| manipulatedValueUnit | x   |     | Input    | Int       |         | Manipulated Value Unit                                                  |          |                   |
| scaleMin             | x   |     | Input    | Real      | 0.0     | Scale Min for read value                                                |          |                   |
| scaleMax             | x   |     | Input    | Real      | 100.0   | Scale Max for read value                                                |          |                   |
| scaleMinMV           | x   |     | Input    | Real      | 0.0     | Scale Min for Manipulated Value                                         |          |                   |
| scaleMaxMV           | x   |     | Input    | Real      | 100.0   | Scale Max for Manipulated Value                                         |          |                   |
| proportional         | x   |     | Input    | Real      | 1.0     | Proportional Parameter                                                  |          |                   |
| integration          | x   |     | Input    | Real      | 0.1     | Integration Parameter in s                                              |          |                   |
| derivation           | x   |     | Input    | Real      | 0.0     | Derivation Parameter in s                                               |          |                   |
| alarmHigh            | x   |     | Input    | Real      |         | Limit Value for Alarm High                                              |          |                   |
| warningHigh          | x   |     | Input    | Real      |         | Limit Value for Warning High                                            |          |                   |
| toleranceHigh        | x   |     | Input    | Real      |         | Limit Value for Tolerance High                                          |          |                   |
| toleranceLow         | x   |     | Input    | Real      |         | Limit Value for Tolerance Low                                           |          |                   |
| warningLow           | x   |     | Input    | Real      |         | Limit Value for Warning Low                                             |          |                   |
| alarmLow             | x   |     | Input    | Real      |         | Limit Value for Alarm Low                                               |          |                   |
| alarmHighEn          | x   |     | Input    | Bool      |         | Alarm High Limit Enabled                                                |          |                   |
| warningHighEn        | x   |     | Input    | Bool      |         | Warning High Limit Enabled                                              |          |                   |
| toleranceHighEn      | x   |     | Input    | Bool      |         | Tolerance High Limit Enabled                                            |          |                   |
| toleranceLowEn       | x   |     | Input    | Bool      |         | Tolerance Low Limit Enabled                                             |          |                   |
| warningLowEn         | x   |     | Input    | Bool      |         | Warning Low Limit Enabled                                               |          |                   |
| alarmLowEn           | x   |     | Input    | Bool      |         | Alarm Low Limit Enabled                                                 |          |                   |
| deadband             | x   |     | Input    | Real      |         | Deadband for alarms/warnings                                            |          |                   |
| externalFault        | x   |     | Input    | Bool      |         | Fault indication from outside                                           |          |                   |
| setpointOut          | x   |     | Output   | Real      |         | Active setpoint                                                         |          |                   |
| valueOut             | x   |     | Output   | Real      |         | input Value for use in the program                                      |          |                   |
| manipulatedValue     | x   |     | Output   | Real      |         | manipulated value                                                       |          |                   |
| remote               | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                  |          |                   |
| operatorMode         | x   |     | Output   | Bool      |         | Operator Mode                                                           |          |                   |
| automaticMode        | x   |     | Output   | Bool      |         | Automatic Mode                                                          |          |                   |
| offlineMode          | x   |     | Output   | Bool      |         | Offline Mode                                                            |          |                   |
| error                | x   |     | Output   | Bool      |         | Any error active                                                        |          |                   |
| alarmHighStatus      | x   |     | Output   | Bool      |         | Alarm High Limit Active                                                 |          |                   |
| warningHighStatus    | x   |     | Output   | Bool      |         | Warning High Limit Active                                               |          |                   |
| toleranceHighStatus  | x   |     | Output   | Bool      |         | Tolerance High Limit Active                                             |          |                   |
| toleranceLowStatus   | x   |     | Output   | Bool      |         | Tolerance Low Limit Active                                              |          |                   |
| warningLowStatus     | x   |     | Output   | Bool      |         | Warning Low Limit Active                                                |          |                   |
| alarmLowStatus       | x   |     | Output   | Bool      |         | Alarm Low Limit Active                                                  |          |                   |
| programSelectsSP     | x   |     | Output   | Bool      |         |                                                                         |          |                   |
| operatorSelectsSP    | x   |     | Output   | Bool      |         |                                                                         |          |                   |
| manualSPAct          | x   |     | Output   | Bool      |         |                                                                         |          |                   |
| internalSPAct        | x   |     | Output   | Bool      |         |                                                                         |          |                   |
| dynamicSPAct         | x   |     | Output   | Bool      |         | Will be active on startup                                               |          |                   |
| fixedSPAct           | x   |     | Output   | Bool      |         |                                                                         |          |                   |
|                      |     |     |          |           |         |                                                                         |          |                   |


## Functionality

| Target            | MTP signal | MTP | SCD | Expression                                                                      | Comment                                      |
| ----------------- | ---------- | --- | --- | ------------------------------------------------------------------------------- | -------------------------------------------- |
| WQC               | x          | x   |     | 16#FF                                                                           | no QC available (default)                    |
| OSLevel           |            | x   |     | 16#00                                                                           | TODO                                         |
| remote            |            | x   |     | StateChannel                                                                    |                                              |
| operatorMode      |            | x   |     | StateOpAct                                                                      |                                              |
| automaticMode     |            | x   |     | StateAutAct                                                                     |                                              |
| offlineMode       |            | x   |     | StateOffAct                                                                     |                                              |
| programSelectsSP  |            | x   |     | SrcChannel                                                                      |                                              |
| operatorSelectsSP |            | x   |     | NOT SrcChannel                                                                  |                                              |
| internalSPAct     |            | x   |     | SrcIntAct                                                                       |                                              |
| manualSPAct       |            | x   |     | SrcManAct                                                                       |                                              |
| SrcManAut         | x          | x   |     | activateManualSP                                                                |                                              |
| SrcIntAut         | x          | x   |     | activateDynamicSP OR activateFixedSP                                            |                                              |
| fixedSPAct        |            | x   |     | Set: activateFixedSP                                                            | Only relevant if internalSPAct               |
|                   |            |     |     | Reset: activateDynamicSP                                                        |                                              |
| dynamicSPAct      |            | x   |     | NOT fixedSPAct                                                                  | Only relevant if internalSPAct               |
| PV                | x          | x   |     | scaleMin + (WORD_TO_DINT(rawValue) / 27648.0) * (scaleMax - scaleMin)           |                                              |
| valueOut          |            | x   |     | PV                                                                              |                                              |
| PVSclMin          | x          | x   |     | scaleMin                                                                        |                                              |
| PVSclMax          | x          | x   |     | scaleMax                                                                        |                                              |
| PVUnit            | x          | x   |     | valueUnit                                                                       |                                              |
| SPInt             | x          | x   |     | (dynamicSP * BOOL_TO_REAL(dynamicSPAct)) + (fixedSP * BOOL_TO_REAL(fixedSPAct)) |                                              |
| SPSclMin          | x          | x   |     | scaleMin                                                                        | SP and PV should have same scale             |
| SPSclMax          | x          | x   |     | scaleMax                                                                        | SP and PV should have same scale             |
| SPUnit            | x          | x   |     | valueUnit                                                                       | SP and PV should have same unit              |
| SPIntMin          | x          | x   |     | scaleMin                                                                        | no limits for now                            |
| SPIntMax          | x          | x   |     | scaleMax                                                                        | no limits for now                            |
| SPManMin          | x          | x   |     | scaleMin                                                                        | no limits for now                            |
| SPManMax          | x          | x   |     | scaleMax                                                                        | no limits for now                            |
| setpointOut       |            | x   |     | SP                                                                              |                                              |
| manipulatedValue  |            | x   |     | MV                                                                              |                                              |
| MVMin             | x          | x   |     | scaleMinMV                                                                      |                                              |
| MVMax             | x          | x   |     | scaleMaxMV                                                                      |                                              |
| MVUnit            | x          | x   |     | manipulatedValueUnit                                                            |                                              |
| MVSclMin          | x          | x   |     | scaleMinMV                                                                      |                                              |
| MVSclMax          | x          | x   |     | scaleMaxMV                                                                      |                                              |
| proportional      |            | x   |     | SyncWith P                                                                      |                                              |
| integration       |            | x   |     | SyncWith Ti                                                                     |                                              |
| derivation        |            | x   |     | SyncWith Td                                                                     |                                              |
| activateManualSP  |            | x   |     | False                                                                           | Reset activateManualSP at the end of the FB  |
| activateDynamicSP |            | x   |     | False                                                                           | Reset activateDynamicSP at the end of the FB |
| activateFixedSP   |            | x   |     | False                                                                           | Reset activateFixedSP at the end of the FB   |
|                   |            |     |     |                                                                                 |                                              |

