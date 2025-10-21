# Reversing Motor

## MTP Interface

[MonBinDrv](./../MTP/MonBinDrv.md)

## Variable Table

| Variable        | MTP | SCD | Var Type | Data Type | Default | Description                                                               | SCD Name | SCD Terminal Name |
| --------------- | --- | --- | -------- | --------- | ------- | ------------------------------------------------------------------------- | -------- | ----------------- |
| MTPBase         | x   | x   | InOut    | MonBinDrv |         |                                                                           |          |                   |
| id              | x   | x   | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects             |          |                   |
| forward         | x   |     | Input    | Bool      |         | Forward command from program                                              |          |                   |
| reverse         | x   |     | Input    | Bool      |         | Reverse command from program                                              |          |                   |
| stop            | x   |     | Input    | Bool      |         | Stop command from program                                                 |          |                   |
| forwardFeedback | x   |     | Input    | Bool      |         | Forward feedback signal from device                                       |          |                   |
| reverseFeedback | x   |     | Input    | Bool      |         | Reverse feedback signal from device                                       |          |                   |
| hasFwdFeedback  | x   |     | Input    | Bool      | True    | Has forward feedback                                                      |          |                   |
| hasRevFeedback  | x   |     | Input    | Bool      | True    | Has reverse feedback                                                      |          |                   |
| enableForward   | x   |     | Input    | Bool      | True    | Enable Forward                                                            |          |                   |
| enableReverse   | x   |     | Input    | Bool      | False   | Enable Reverse                                                            |          |                   |
| driveTrip       | x   |     | Input    | Bool      |         | Drive Protection Indicator. 0: tripped, 1: no error                       |          |                   |
| safeHold        | x   |     | Input    | Bool      |         | Holds Energize on interlock                                               |          |                   |
| monitor         | x   |     | Input    | Bool      | True    | Enables errors on the feedback monitoring                                 |          |                   |
| staticTimeout   | x   |     | Input    | Real      | 2       | Amount of time before a static monitoring error is triggered              |          |                   |
| dynamicTimeout  | x   |     | Input    | Real      | 5       | Amount of time before a dynamic monitoring error is triggered             |          |                   |
| simulate        | x   |     | Input    | Bool      |         | Enable simulation                                                         |          |                   |
| simulateDelay   | x   |     | Input    | Real      | 1       | Simulated delay to set the feedback signals, in s                         |          |                   |
| interlockIn     | x   |     | Input    | Bool      |         | forces safe position. 0 = interlock active                                |          |                   |
| permitIn        | x   |     | Input    | Bool      | 1       | permission to control. Does not activate safe position. 0 = no permission |          |                   |
| protectIn       | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active        |          |                   |
| reset           | x   |     | Input    | Bool      |         | will try to reset itself TODO: better description                         |          |                   |
| fwdCommand      | x   |     | Output   | Bool      |         | Forward command to device                                                 |          |                   |
| revCommand      | x   |     | Output   | Bool      |         | Reverse command to device                                                 |          |                   |
| forwardActive   | x   |     | Output   | Bool      |         | Motor running forward                                                     |          |                   |
| reverseActive   | x   |     | Output   | Bool      |         | Motor running reverse                                                     |          |                   |
| stopped         | x   |     | Output   | Bool      |         | Motor stopped                                                             |          |                   |
| fwdFbkSimulated | x   | x   | Local    | Bool      |         | Simulated forward feedback                                                |          |                   |
| revFbkSimulated | x   | x   | Local    | Bool      |         | Simulated reverse feedback                                                |          |                   |
| remote          | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                   |
| operatorMode    | x   |     | Output   | Bool      |         | Operator Mode                                                             |          |                   |
| automaticMode   | x   |     | Output   | Bool      |         | Automatic Mode                                                            |          |                   |
| offlineMode     | x   |     | Output   | Bool      |         | Offline Mode                                                              |          |                   |
|                 |     |     |          |           |         |                                                                           |          |                   |

## Functionality

| Target          | MTP signal | MTP | SCD | Expression                                                               | Comment                                                     |
| --------------- | ---------- | --- | --- | ------------------------------------------------------------------------ | ----------------------------------------------------------- |
| WQC             | x          | x   |     | 16#FF                                                                    | no QC available (default)                                   |
| OSLevel         |            | x   |     | 16#00                                                                    | TODO                                                        |
| remote          |            | x   |     | StateChannel                                                             |                                                             |
| operatorMode    |            | x   |     | StateOpAct                                                               |                                                             |
| automaticMode   |            | x   |     | StateAutAct                                                              |                                                             |
| offlineMode     |            | x   |     | StateOffAct                                                              |                                                             |
| PermEn          | x          | x   |     | True                                                                     | Always Enable, Configure permitIn = 0 if no permits         |
| IntlEn          | x          | x   |     | True                                                                     | Always Enable, Configure interlockIn = 0 if no interlocks   |
| ProtEn          | x          | x   |     | True                                                                     | Always Enable, Configure protectIn = 0 if no protections    |
| Permit          | x          | x   |     | permitIn                                                                 |                                                             |
| Interlock       | x          | x   |     | NOT interlockIn                                                          | Normalize logic so it's easier to build complex interlocks  |
| Protect         | x          | x   |     | NOT protectIn                                                            | Set (reset because inverted logic) happens inside MTP block |
| SafePos         | x          | x   |     | false                                                                    |                                                             |
| FwdEn           | x          | x   |     | enableForward                                                            |                                                             |
| RevEn           | x          | x   |     | enableReverse                                                            |                                                             |
| StopAut         | x          | x   |     | (NOT forward AND NOT reverse) OR stop                                    |                                                             |
| FwdAut          | x          | x   |     | Set: forward AND NOT stop                                                |                                                             |
|                 |            |     |     | Reset: stop                                                              |                                                             |
| RevAut          | x          | x   |     | Set: reverse AND NOT stop                                                |                                                             |
|                 |            |     |     | Reset: stop                                                              |                                                             |
| fwdCommand      |            | x   |     | FwdCtrl                                                                  |                                                             |
| revCommand      |            | x   |     | RevCtrl                                                                  |                                                             |
| FwdFbkCalc      | x          | x   |     | simulate OR NOT hasFwdFeedback                                           |                                                             |
| RevFbkCalc      | x          | x   |     | simulate OR NOT hasRevFeedback                                           |                                                             |
| fwdFbkSimulated |            | x   |     | FwdFbkCalc AND fwdCommand for simulateDelay                              |                                                             |
| revFbkSimulated |            | x   |     | RevFbkCalc AND revCommand for simulateDelay                              |                                                             |
| FwdFbk          | x          | x   |     | (forwardFeedback AND NOT FwdFbkCalc) OR (fwdFbkSimulated AND FwdFbkCalc) |                                                             |
| RevFbk          | x          | x   |     | (reverseFeedback AND NOT RevFbkCalc) OR (revFbkSimulated AND RevFbkCalc) |                                                             |
| forwardActive   |            | x   |     | FwdFbk                                                                   |                                                             |
| reverseActive   |            | x   |     | RevFbk                                                                   |                                                             |
| stopped         |            | x   |     | NOT FwdFbk AND NOT RevFbk                                                |                                                             |
| Trip            | x          | x   |     | NOT driveTrip                                                            | (True = trip active)                                        |
| ResetAut        | x          | x   |     | reset                                                                    |                                                             |
| MonSafePos      | x          | x   |     | safeHold                                                                 |                                                             |
| MonStatTi       | x          | x   |     | staticTimeout                                                            |                                                             |
| MonDynTi        | x          | x   |     | dynamicTimeout                                                           |                                                             |
| reset           |            | x   |     | False                                                                    | reset = False at the end of the FB                          |
| stop            |            | x   |     | False                                                                    | stop = False at the end of the FB                           |
|                 |            |     |     |                                                                          |                                                             |
