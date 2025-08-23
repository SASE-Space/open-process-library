# VFD (Variable Frequency Drive)

## MTP Interface

[VFD](./../MTP/MonAnaDrv.md)

## Variable Table

| Variable          | MTP | SCD | Var Type | Data Type | Default | Description                                                               | SCD Name | SCD Terminal Name |
| ----------------- | --- | --- | -------- | --------- | ------- | ------------------------------------------------------------------------- | -------- | ----------------- |
| MTPBase           | x   | x   | InOut    | MonAnaDrv |         |                                                                           |          |                   |
| forward           | x   |     | Input    | Bool      |         | Forward command from program                                              |          |                   |
| reverse           | x   |     | Input    | Bool      |         | Reverse command from program                                              |          |                   |
| speed             | x   |     | Input    | Real      |         | Speed command from program                                                |          |                   |
| speedUnit         | x   |     | Input    | Int       |         | Speed Unit (%, RPM, ...)                                                  |          |                   |
| speedMin          | x   |     | Input    | Real      | 0       | Speed Min                                                                 |          |                   |
| speedMax          | x   |     | Input    | Real      | 100     | Speed Max                                                                 |          |                   |
| forwardFeedback   | x   |     | Input    | Bool      |         | Forward feedback signal from device                                       |          |                   |
| reverseFeedback   | x   |     | Input    | Bool      |         | Reverse feedback signal from device                                       |          |                   |
| speedFeedback     | x   |     | Input    | Word      |         | Speed feedback                                                            |          |                   |
| speedScaleMin     | x   |     | Input    | Real      |         | Speed scale min                                                           |          |                   |
| speedScaleMax     | x   |     | Input    | Real      |         | Speed scale max                                                           |          |                   |
| hasFwdFeedback    | x   |     | Input    | Bool      | True    | Has forward feedback                                                      |          |                   |
| hasRevFeedback    | x   |     | Input    | Bool      | True    | Has reverse feedback                                                      |          |                   |
| enableForward     | x   |     | Input    | Bool      |         | Enable Forward                                                            |          |                   |
| enableReverse     | x   |     | Input    | Bool      |         | Enable Reverse                                                            |          |                   |
| trip              | x   |     | Input    | Bool      | True    | Drive Protection Indicator. 0: tripped, 1: no error                       |          |                   |
| safeHold          | x   |     | Input    | Bool      |         | Holds Energize on interlock                                               |          |                   |
| monitor           | x   |     | Input    | Bool      | True    | Enables errors on the feedback monitoring                                 |          |                   |
| staticTimeout     | x   |     | Input    | Real      | 2       | Amount of time before a static monitoring error is triggered              |          |                   |
| dynamicTimeout    | x   |     | Input    | Real      | 5       | Amount of time before a dynamic monitoring error is triggered             |          |                   |
| simulate          | x   |     | Input    | Bool      |         | Enable simulation                                                         |          |                   |
| simulateDelay     | x   |     | Input    | Real      | 1       | Simulated delay to set the feedback signals, in s                         |          |                   |
| interlockIn       | x   |     | Input    | Bool      |         | forces safe position. 0 = interlock active                                |          |                   |
| permitIn          | x   |     | Input    | Bool      | 1       | permission to control. Does not activate safe position. 0 = no permission |          |                   |
| protectIn         | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active        |          |                   |
| reset             | x   |     | Input    | Bool      |         | will try to reset itself TODO: better description                         |          |                   |
| fwdCommand        | x   |     | Output   | Bool      |         | Forward command to device                                                 |          |                   |
| revCommand        | x   |     | Output   | Bool      |         | Reverse command to device                                                 |          |                   |
| forwardActive     | x   |     | Output   | Bool      |         | Motor running forward                                                     |          |                   |
| reverseActive     | x   |     | Output   | Bool      |         | Motor running reverse                                                     |          |                   |
| fwdFbkSimulated   | x   | x   | Local    | Bool      |         | Simulated forward feedback                                                |          |                   |
| revFbkSimulated   | x   | x   | Local    | Bool      |         | Simulated reverse feedback                                                |          |                   |
| actualSpeed       | x   |     | Output   | Real      |         | Actual motor speed                                                        |          |                   |
| remote            | x   | x   | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                   |
| operator          | x   | x   | Output   | Bool      |         | Operator Mode                                                             |          |                   |
| automatic         | x   | x   | Output   | Bool      |         | Automatic Mode                                                            | BA       | Status auto/man   |
| offline           | x   | x   | Output   | Bool      |         | Offline Mode                                                              |          |                   |
| remoteSource      | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                   |
| internalSourceAct | x   |     | Output   | Bool      |         |                                                                           |          |                   |
| manualSourceAct   | x   |     | Output   | Bool      |         |                                                                           |          |                   |
|                   |     |     |          |           |         |                                                                           |          |                   |


## Functionality

| Target            | MTP signal | MTP | SCD | Expression                                                            | Comment                                                   |
| ----------------- | ---------- | --- | --- | --------------------------------------------------------------------- | --------------------------------------------------------- |
| WQC               | x          | x   |     | 16#FF                                                                 | no QC available (default)                                 |
| OSLevel           |            | x   |     | 16#00                                                                 | TODO                                                      |
| remote            |            | x   |     | StateChannel                                                          |                                                           |
| operator          |            | x   |     | StateOpAct                                                            |                                                           |
| automatic         |            | x   |     | StateAutAct                                                           |                                                           |
| offline           |            | x   |     | StateOffAct                                                           |                                                           |
| remoteSource      |            | x   |     | SrcChannel                                                            |                                                           |
| internalSourceAct |            | x   |     | SrcIntAct                                                             |                                                           |
| manualSourceAct   |            | x   |     | SrcManAct                                                             |                                                           |
| PermEn            | x          | x   |     | True                                                                  | Always Enable, Configure permitIn = 0 if no permits       |
| IntlEn            | x          | x   |     | True                                                                  | Always Enable, Configure interlockIn = 0 if no interlocks |
| ProtEn            | x          | x   |     | True                                                                  | Always Enable, Configure protectIn = 0 if no protections  |
| Permit            | x          | x   |     | permitIn                                                              |                                                           |
| Interlock         | x          | x   |     | interlockIn                                                           |                                                           |
| Protect           | x          | x   |     | Set: protectIn                                                        | Reset happens inside MTP block                            |
| SafePos           | x          | x   |     | False                                                                 |                                                           |
| FwdAut            | x          | x   |     | forward                                                               |                                                           |
| RevAut            | x          | x   |     | reverse                                                               |                                                           |
| fwdCommand        |            | x   |     | FwdCtrl                                                               |                                                           |
| revCommand        |            | x   |     | RevCtrl                                                               |                                                           |
| FwdFbkCalc        | x          | x   |     | simulate OR NOT hasFwdFeedback                                        |                                                           |
| RevFbkCalc        | x          | x   |     | simulate OR NOT hasRevFeedback                                        |                                                           |
| fwdFbkSimulated   |            | x   |     | (simulate OR NOT hasFwdFeedback) AND fwdCommand for simulateDelay     |                                                           |
| revFbkSimulated   |            | x   |     | (simulate OR NOT hasRevFeedback) AND NOT revCommand for simulateDelay |                                                           |
| FwdFbk            | x          | x   |     | forwardFeedback OR fwdFbkSimulated                                    |                                                           |
| RevFbk            | x          | x   |     | reverseFeedback OR revFbkSimulated                                    |                                                           |
| Trip              | x          | x   |     | trip                                                                  |                                                           |
| ResetAut          | x          | x   |     | reset                                                                 |                                                           |
| RpmSclMin         | x          | x   |     | speedMin                                                              |                                                           |
| RpmSclMax         | x          | x   |     | speedMax                                                              |                                                           |
| RpmUnit           | x          | x   |     | speedUnit                                                             | Fixed on % (TODO: look up int value for %)                |
| RpmMin            | x          | x   |     | speedMin                                                              | Make identical to scale                                   |
| RpmMax            | x          | x   |     | speedMax                                                              | Make identical to scale                                   |
| RpmRbk            | x          | x   |     | speedFeedback                                                         |                                                           |
| actualSpeed       | x          | x   |     | Rpm                                                                   |                                                           |
| reset             |            | x   |     | False                                                                 | reset = False at the end of the FB                        |
| MonSafePos        | x          | x   |     | safeHold                                                              |                                                           |
| MonStatTi         | x          | x   |     | staticTimeout                                                         |                                                           |
| MonDynTi          | x          | x   |     | dynamicTimeout                                                        |                                                           |
|                   |            |     |     |                                                                       |                                                           |