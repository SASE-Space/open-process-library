# Analog Input

## MTP Interface

[AnaMon](./../MTP/AnaMon.md)

## Variable Table

| Variable         | Var Type | Data Type | Description                    |
| ---------------- | -------- | --------- | ------------------------------ |
| rawValue         | Input    | Word      | Raw Input Value                |
| valueUnit        | Input    | Int       | Value Unit                     |
| scaleMin         | Input    | Real      | Scale Min Limit                |
| scaleMax         | Input    | Real      | Scale Max Limit                |
| alarmHigh        | Input    | Real      | Limit Value for Alarm High     |
| warningHigh      | Input    | Real      | Limit Value for Warning High   |
| toleranceHigh    | Input    | Real      | Limit Value for Tolerance High |
| toleranceLow     | Input    | Real      | Limit Value for Tolerance Low  |
| warningLow       | Input    | Real      | Limit Value for Warning Low    |
| alarmLow         | Input    | Real      | Limit Value for Alarm Low      |
| alarmHighEn      | Input    | Bool      | Alarm High Limit Enabled       |
| warningHighEn    | Input    | Bool      | Warning High Limit Enabled     |
| toleranceHighEn  | Input    | Bool      | Tolerance High Limit Enabled   |
| toleranceLowEn   | Input    | Bool      | Tolerance Low Limit Enabled    |
| warningLowEn     | Input    | Bool      | Warning Low Limit Enabled      |
| alarmLowEn       | Input    | Bool      | Alarm Low Limit Enabled        |
| deadband         | Input    | Real      | Deadband for alarms/warnings   | TODO (3)
| vOut             | Output   | Real      | Value                          | TODO (1)
| alarmHighAct     | Output   | Bool      | Alarm High Limit Active        |
| warningHighAct   | Output   | Bool      | Alarm High Limit Active        |
| toleranceHighAct | Output   | Bool      | Alarm High Limit Active        |
| toleranceLowAct  | Output   | Bool      | Alarm High Limit Active        |
| warningLowAct    | Output   | Bool      | Alarm High Limit Active        |
| alarmLowAct      | Output   | Bool      | Alarm High Limit Active        |


(3) absolute value or %? Also need to add alarms that use this deadband

## Functionality

| Target        | MTP | Expression                                                    | Comment                   |
| ------------- | --- | ------------------------------------------------------------- | ------------------------- |
| WQC           | x   | 16#FF                                                         | no QC available (default) |
| OSLevel       |     | TODO                                                          |                           |
| V             | x   | scaleMin + (REAL(RawInput) / 27648.0) * (scaleMax - scaleMin) |                           |
| vOut          |     | V                                                             |                           |
| VSclMin       | x   | scaleMin                                                      |                           |
| VSclMax       | x   | scaleMax                                                      |                           |
| VUnit         | x   | valueUnit                                                     |                           |
| alarmHigh     |     | VAHLim                                                        | synchronize (1)           |
| warningHigh   |     | VWHLim                                                        | synchronize (1)           |
| toleranceHigh |     | VTHLim                                                        | synchronize (1)           |
| toleranceLow  |     | VTLLim                                                        | synchronize (1)           |
| warningLow    |     | VWLLim                                                        | synchronize (1)           |
| alarmLow      |     | VALLim                                                        | synchronize (1)           |
| VAHEn         | x   | alarmHighEn                                                   |                           |
| VWHEn         | x   | warningHighEn                                                 |                           |
| VTHEn         | x   | toleranceHighEn                                               |                           |
| VTLEn         | x   | toleranceLowEn                                                |                           |
| VWLEn         | x   | warningLowEn                                                  |                           |
| VALEn         | x   | alarmLowEn                                                    |                           |
|               |     |                                                               |                           |
|               |     |                                                               |                           |

## Synchronize (1)

For example:
- alarmHigh is an Input on AnalogInput
- VAHLim is a Local on AnaMon

During initial scan: copy AnaMon.VAHLim = alarmHigh

To synchronize both values after the first scan we need to detect where the change is coming from.
We can do this by adding a local variable: alarmHighLast.
At the end of the Function Block alarmHigh is copied to alarmHighLast

If alarmHighLast is not the same as alarmHigh then it means someone adjusted the input, and the value needs to be copied to VAHLim.
If alarmHighLast is the same as alarmHigh BUT VAHLim is not the same as alarmHigh then VAHLim needs to be copied to VAHLim

Note1: we need this kind of logic each time a value can be changed both on the POL and in the PLC
Note2: we could avoid this logic and extra 'Last' variable by inheritance. However inheritance doesn't solve:
- allow giving nice names. The MTP variables are quite cryptic
- not every IEC-61131 dialect supports inheritance



## TODO
- OSLevel

