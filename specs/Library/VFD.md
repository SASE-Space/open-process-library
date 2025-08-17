# VFD (Variable Frequency Drive)

## MTP Interface

[AnaMon](./../MTP/MonAnaDrv.md)

## Variable Table

| Variable        | MTP | SCD | Var Type | Data Type | Default | Description                                                   | SCD Name | SCD Terminal Name |
| --------------- | --- | --- | -------- | --------- | ------- | ------------------------------------------------------------- | -------- | ----------------- |
| MTPBase         | x   | x   | InOut    | MonAnaDrv |         |                                                               |          |                   |
| forward         | x   |     | Input    | Bool      |         | Forward command from program                                  |          |                   |
| reverse         | x   |     | Input    | Bool      |         | Reverse command from program                                  |          |                   |
| speed           | x   |     | Input    | Real      |         | Speed command from program                                    |          |                   |
| speedUnit       | x   |     | Input    | Int       |         | Speed Unit (%, RPM, ...)                                      |          |                   |
| speedMin        | x   |     | Input    | Real      | 0       | Speed Min                                                     |          |                   |
| speedMax        | x   |     | Input    | Real      | 100     | Speed Max                                                     |          |                   |
| forwardFeedback | x   |     | Input    | Bool      |         | Forward feedback signal from device                           |          |                   |
| reverseFeedback | x   |     | Input    | Bool      |         | Reverse feedback signal from device                           |          |                   |
| speedFeedback   | x   |     | Input    | Word      |         | Speed feedback                                                |          |                   |
| speedScaleMin   | x   |     | Input    | Real      |         | Speed scale min                                               |          |                   |
| speedScaleMax   | x   |     | Input    | Real      |         | Speed scale max                                               |          |                   |
| hasFwdFeedback  | x   |     | Input    | Bool      | True    | Has forward feedback                                          |          |                   |
| hasRevFeedback  | x   |     | Input    | Bool      | True    | Has reverse feedback                                          |          |                   |
| enableForward   | x   |     | Input    | Bool      |         | Enable Forward                                                |          |                   |
| enableReverse   | x   |     | Input    | Bool      |         | Enable Reverse                                                |          |                   |
| trip            | x   |     | Input    | Bool      | True    | Drive Protection Indicator. 0: tripped, 1: no error           |          |                   |
| safeHold        | x   |     | Input    | Bool      |         | Holds Energize on interlock                                   |          |                   |
| monitor         | x   |     | Input    | Bool      | True    | Enables errors on the feedback monitoring                     |          |                   |
| staticTimeout   | x   |     | Input    | Real      | 2       | Amount of time before a static monitoring error is triggered  |          |                   |
| dynamicTimeout  | x   |     | Input    | Real      | 5       | Amount of time before a dynamic monitoring error is triggered |          |                   |
| simulate        | x   |     | Input    | Bool      |         | Enable simulation                                             |          |                   |
| simulateDelay   | x   |     | Input    | Bool      | 1       | Simulated delay to set the feedback signals, in s             |          |                   |
| reset           | x   |     | Input    | Bool      |         | will try to reset itself TODO: better description             |          |                   |
| forwardCommand  | x   |     | Output   | Bool      |         | Forward command to device                                     |          |                   |
| reverseCommad   | x   |     | Output   | Bool      |         | Reverse command to device                                     |          |                   |
| forwardActive   | x   |     | Output   | Bool      |         | Motor running forward                                         |          |                   |
| reverseActive   | x   |     | Output   | Bool      |         | Motor running reverse                                         |          |                   |
| actualSpeed     | x   |     | Output   | Real      |         | Actual motor speed                                            |          |                   |
|                 |     |     |          |           |         |                                                               |          |                   |


## Functionality

| Target               | MTP signal | MTP | SCD | Expression                                                            | Comment                                                   |
| -------------------- | ---------- | --- | --- | --------------------------------------------------------------------- | --------------------------------------------------------- |
| WQC                  | x          | x   |     | 16#FF                                                                 | no QC available (default)                                 |
| OSLevel              |            | x   |     | TODO                                                                  |                                                           |
| remote               |            | x   |     | StateChannel                                                          |                                                           |
| operator             |            | x   |     | StateOpAct                                                            |                                                           |
| automatic            |            | x   |     | StateAutAct                                                           |                                                           |
| offline              |            | x   |     | StateOffAct                                                           |                                                           |
| remoteSource         |            | x   |     | SrcChannel                                                            |                                                           |
| internalSourceAct    |            | x   |     | SrcIntAct                                                             |                                                           |
| manualSourceAct      |            | x   |     | SrcManAct                                                             |                                                           |
| PermEn               | x          | x   |     | True                                                                  | Always Enable, Configure permitIn = 0 if no permits       |
| IntlEn               | x          | x   |     | True                                                                  | Always Enable, Configure interlockIn = 0 if no interlocks |
| ProtEn               | x          | x   |     | True                                                                  | Always Enable, Configure protectIn = 0 if no protections  |
| Permit               | x          | x   |     | permitIn                                                              |                                                           |
| Interlock            | x          | x   |     | interlockIn                                                           |                                                           |
| Protect              | x          | x   |     | Set: protectIn                                                        | Reset happens inside MTP block                            |
| SafePos              | x          | x   |     | False                                                                 |                                                           |
| SafePosEn            | x          | x   |     | safeHold                                                              |                                                           |
| FwdAut               | x          | x   |     | open                                                                  |                                                           |
| RevAut               | x          | x   |     | close                                                                 |                                                           |
| forwardCommand       |            | x   |     | FwdCtrl                                                               |                                                           |
| reverseCommad        |            | x   |     | RevCtrl                                                               |                                                           |
| FwdFbkCalc           | x          | x   |     | simulate OR NOT hasFwdFeedback                                        |                                                           |
| RevFbkCalc           | x          | x   |     | simulate OR NOT hasRevFeedback                                        |                                                           |
| fwdFeedbackSimulated |            | x   |     | (simulate OR NOT hasFwdFeedback) AND fwdCommand for simulateDelay     |                                                           |
| refFeedbackSimulated |            | x   |     | (simulate OR NOT hasRevFeedback) AND NOT revCommand for simulateDelay |                                                           |
| FwdFbk               | x          | x   |     | forwardFeedback OR fwdFeedbackSimulated                               |                                                           |
| RevFbk               | x          | x   |     | reverseFeedback OR refFeedbackSimulated                               |                                                           |
| Trip                 | x          | x   |     | trip                                                                  |                                                           |
| ResetAut             | x          | x   |     | reset                                                                 |                                                           |
| RpmSclMin            | x          | x   |     | speedMin                                                              |                                                           |
| RpmSclMax            | x          | x   |     | speedMax                                                              |                                                           |
| RpmUnit              | x          | x   |     | speedUnit                                                             | Fixed on % (TODO: look up int value for %)                |
| RpmMin               | x          | x   |     | speedMin                                                              | Make identical to scale                                   |
| RpmMax               | x          | x   |     | speedMax                                                              | Make identical to scale                                   |
| PosInt               | x          | x   |     | targetPosition                                                        |                                                           |
| RpmRbk               | x          | x   |     | speedFeedback                                                         |                                                           |
| speedOut             | x          | x   |     | Rpm                                                                   |                                                           |
| reset                |            | x   |     | False                                                                 | reset = False at the end of the FB                        |
| MonSafePos           | x          | x   |     | safeHold                                                              |                                                           |
| MonStatTi            | x          | x   |     | staticTimeout                                                         |                                                           |
| MonDynTi             | x          | x   |     | dynamicTimeout                                                        |                                                           |
|                      |            |     |     |                                                                       |                                                           |