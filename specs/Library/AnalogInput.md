# Analog Input

## MTP Interface

[AnaMon](./../MTP/AnaMon.md)

## Variable Table

| Variable            | MTP | SCD | Var Type | Data Type | Default | Description                                                    | SCD Name | SCD Terminal Name          |
| ------------------- | --- | --- | -------- | --------- | ------- | -------------------------------------------------------------- | -------- | -------------------------- |
| MTPBase             | x   | x   | InOut    | AnaMon    |         |                                                                |          |                            |
| rawValue            | x   | x   | Input    | Word      |         | Raw Input Value                                                | X        | Normal function input      |
| valueUnit           | x   | x   | Input    | Int       |         | Value Unit                                                     |          |                            |
| scaleMin            | x   | x   | Input    | Real      |         | Scale Min Limit                                                |          |                            |
| scaleMax            | x   | x   | Input    | Real      |         | Scale Max Limit                                                |          |                            |
| alarmHigh           | x   | x   | Input    | Real      |         | Limit Value for Alarm High                                     |          |                            |
| warningHigh         | x   | x   | Input    | Real      |         | Limit Value for Warning High                                   |          |                            |
| toleranceHigh       | x   |     | Input    | Real      |         | Limit Value for Tolerance High                                 |          |                            |
| toleranceLow        | x   |     | Input    | Real      |         | Limit Value for Tolerance Low                                  |          |                            |
| warningLow          | x   | x   | Input    | Real      |         | Limit Value for Warning Low                                    |          |                            |
| alarmLow            | x   | x   | Input    | Real      |         | Limit Value for Alarm Low                                      |          |                            |
| alarmHighEn         | x   |     | Input    | Bool      |         | Alarm High Limit Enabled                                       |          |                            |
| warningHighEn       | x   |     | Input    | Bool      |         | Warning High Limit Enabled                                     |          |                            |
| toleranceHighEn     | x   |     | Input    | Bool      |         | Tolerance High Limit Enabled                                   |          |                            |
| toleranceLowEn      | x   |     | Input    | Bool      |         | Tolerance Low Limit Enabled                                    |          |                            |
| warningLowEn        | x   |     | Input    | Bool      |         | Warning Low Limit Enabled                                      |          |                            |
| alarmLowEn          | x   |     | Input    | Bool      |         | Alarm Low Limit Enabled                                        |          |                            |
| blockAlarmHigh      |     | x   | Input    | Bool      |         | Block HH action, but not alarm                                 | FBHH     | Force blocking alarm HH    |
| surpressAlarmHigh   |     | x   | Input    | Bool      |         | Surpress HH action and alarm                                   | FUHH     | Force suppression alarm HH |
| surpressWarningHigh |     | x   | Input    | Bool      |         | Surpress WH (there is no action)                               | FUWH     | Force suppression alarm WH |
| surpresWarningLow   |     | x   | Input    | Bool      |         | Surpress WL (there is no action)                               | FUWL     | Force suppression alarm WL |
| surpressAlarmLow    |     | x   | Input    | Bool      |         | Surpress LL action and alarm                                   | FULL     | Force suppression alarm LL |
| blockAlarmLow       |     | x   | Input    | Bool      |         | Block LL action, but not alarm                                 | FBLL     | Force blocking alarm LL    |
| deadband            | x   | x   | Input    | Real      |         | Deadband for alarms/warnings                                   |          |                            | TODO (3)
| externalFault       | x   | x   | Input    | Bool      |         | Fault indication from outside                                  | XF       | External Fault             |
| vOut                | x   | x   | Output   | Real      |         | Value                                                          | Y        | Normal function output     | TODO (1)
| error               | x   | x   | Output   | Bool      |         | Any error active                                               | YF       | Function failed            |
| alarmHighAction     |     | x   | Output   | Bool      |         | Alarm High Action Active (can be blocked separate from status) | AHH      | Action alarm HH            |
| alarmHighStatus     | x   | x   | Output   | Bool      |         | Alarm High Limit Active                                        | BHH      | Status alarm HH            |
| warningHighStatus   | x   | x   | Output   | Bool      |         | Warning High Limit Active                                      | WH       | Warning WH                 |
| toleranceHighStatus | x   |     | Output   | Bool      |         | Tolerance High Limit Active                                    |          |                            |
| toleranceLowStatus  | x   |     | Output   | Bool      |         | Tolerance Low Limit Active                                     |          |                            |
| warningLowStatus    | x   | x   | Output   | Bool      |         | Warning Low Limit Active                                       | WL       | Warning WL                 |
| alarmLowStatus      | x   | x   | Output   | Bool      |         | Alarm Low Limit Active                                         | BLL      | Status alarm LL            |
| alarmLowAction      |     | x   | Output   | Bool      |         | Alarm Low Action Active (can be blocked separate from status)  | ALL      | Action alarm LL            |
| alarmHighBlocked    |     | x   | Output   | Bool      |         | Alarm High Blocked                                             | BBHH     | Action alarm HH is blocked |
| alarmLowBlocked     |     | x   | Output   | Bool      |         | Alarm Low Blocked                                              | BBLL     | Action alarm LL is blocked |
| alarmSuppressed     |     | x   | Output   | Bool      |         | True if any alarm is suppressed                                | BU       | Status suppressed          |
| alarmBlocked        |     | x   | Output   | Bool      |         | True if any action is blocked                                  | BB       | Status blocked             |
| alarmHighEvent      |     | x   | Output   | Bool      |         | HH, ignoring suppression                                       | BXHH     | Status event HH            |
| warningHighEvent    |     | x   | Output   | Bool      |         | WH, ignoring suppression                                       | BXH      | Status event H             |
| warningLowEvent     |     | x   | Output   | Bool      |         | WL, ignoring suppression                                       | BXL      | Status event L             |
| alarmLowEvent       |     | x   | Output   | Bool      |         | LL, ignoring suppression                                       | BXLL     | Status event LL            |




(3) absolute value or %? Also need to add alarms that use this deadband

## Functionality

| Target        | MTP signal | MTP | SCD | Expression                                                    | Comment                   |
| ------------- | ---------- | --- | --- | ------------------------------------------------------------- | ------------------------- |
| WQC           | x          | x   |     | 16#FF                                                         | no QC available (default) |
| OSLevel       |            | x   |     | TODO                                                          |                           |
| V             | x          | x   |     | scaleMin + (REAL(RawInput) / 27648.0) * (scaleMax - scaleMin) |                           |
| vOut          |            | x   |     | V                                                             |                           |
| VSclMin       | x          | x   |     | scaleMin                                                      |                           |
| VSclMax       | x          | x   |     | scaleMax                                                      |                           |
| VUnit         | x          | x   |     | valueUnit                                                     |                           |
| alarmHigh     |            | x   |     | VAHLim                                                        | synchronize (1)           |
| warningHigh   |            | x   |     | VWHLim                                                        | synchronize (1)           |
| toleranceHigh |            | x   |     | VTHLim                                                        | synchronize (1)           |
| toleranceLow  |            | x   |     | VTLLim                                                        | synchronize (1)           |
| warningLow    |            | x   |     | VWLLim                                                        | synchronize (1)           |
| alarmLow      |            | x   |     | VALLim                                                        | synchronize (1)           |
| VAHEn         | x          | x   |     | alarmHighEn                                                   |                           |
| VWHEn         | x          | x   |     | warningHighEn                                                 |                           |
| VTHEn         | x          | x   |     | toleranceHighEn                                               |                           |
| VTLEn         | x          | x   |     | toleranceLowEn                                                |                           |
| VWLEn         | x          | x   |     | warningLowEn                                                  |                           |
| VALEn         | x          | x   |     | alarmLowEn                                                    |                           |
|               |            |     |     |                                                               |                           |
|               |            |     |     |                                                               |                           |

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

