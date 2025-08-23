# Analog Valve

## MTP Interface

[MonAnaVlv](./../MTP/MonAnaVlv.md)

## Variable Table

| Variable          | MTP | SCD | Var Type | Data Type | Default | Description                                                               | SCD Name | SCD Terminal Name              |
| ----------------- | --- | --- | -------- | --------- | ------- | ------------------------------------------------------------------------- | -------- | ------------------------------ |
| MTPBase           | x   | x   | InOut    | MonAnaVlv |         |                                                                           |          |                                |
| targetPosition    | x   |     | Input    | Real      |         | Target position from program                                              |          |                                |
| feedbackPosition  | x   |     | Input    | Word      |         | Position feedback (0-100%)                                                |          |                                |
| scaleMin          | x   |     | Input    | Real      | 0       | Position scale min                                                        |          |                                |
| scaleMax          | x   |     | Input    | Real      | 100     | Position scale max                                                        |          |                                |
| feedbackOpen      | x   | x   | Input    | Bool      | True    | feedback open                                                             | XGH      | Position high feedback         |
| feedbackClose     | x   | x   | Input    | Bool      | True    | feedback close                                                            | XGL      | Position low feedback          |
| hasFbOpen         | x   | x   | Input    | Bool      |         | has open feedback                                                         |          |                                |
| hasFbClose        | x   | x   | Input    | Bool      |         | hase close feedback                                                       |          |                                |
| safeOpen          | x   | x   | Input    | Bool      |         | Safe Position is Open                                                     |          |                                |
| safeHold          | x   | x   | Input    | Bool      |         | Holds Position on interlock (priority over safeOpen)                      |          |                                |
| simulate          | x   |     | Input    | Bool      |         | Enable simulation                                                         |          |                                |
| simulateDelay     | x   | x   | Input    | Real      | 1       | Simulated delay to set the feedback signals, in s                         |          |                                |
| interlockIn       | x   |     | Input    | Bool      |         | forces safe position. 0 = interlock active                                |          |                                |
| permitIn          | x   |     | Input    | Bool      | 1       | permission to control. Does not activate safe position. 0 = no permission |          |                                |
| protectIn         | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active        |          |                                |
| reset             | x   |     | Input    | Bool      |         | will try to reset itself                                                  |          |                                |
| positionOutDevice | x   |     | Output   | Word      |         | Command to device (0-100%)                                                |          |                                |
| positionOut       | x   |     | Output   | Real      |         | Command for use in program                                                |          |                                |
| remote            | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                                |
| operator          | x   |     | Output   | Bool      |         | Operator Mode                                                             |          |                                |
| automatic         | x   |     | Output   | Bool      |         | Automatic Mode                                                            |          |                                |
| offline           | x   |     | Output   | Bool      |         | Offline Mode                                                              |          |                                |
| error             | x   | x   | Output   | Bool      |         | Any error active                                                          | YF       | Function failed                |
| opened            | x   | x   | Output   | Bool      |         | Valve is opened                                                           | BCH      | Output position high confirmed |
| closed            | x   | x   | Output   | Bool      |         | Valve is closed                                                           | BCL      | Output position low confirmed  |
| fbOpenSimulated   | x   | x   | Local    | Bool      |         | Simulated open feedback                                                   |          |                                |
| fbCloseSimulated  | x   | x   | Local    | Bool      |         | Simulated Close feedback                                                  |          |                                |
| remoteSource      | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                                |
| internalSourceAct | x   |     | Output   | Bool      |         |                                                                           |          |                                |
| manualSourceAct   | x   |     | Output   | Bool      |         |                                                                           |          |                                |
|                   |     |     |          |           |         |                                                                           |          |                                |


## Functionality

| Target            | MTP signal | MTP | SCD | Expression                                                     | Comment                                                   |
| ----------------- | ---------- | --- | --- | -------------------------------------------------------------- | --------------------------------------------------------- |
| WQC               | x          | x   |     | 16#FF                                                          | no QC available (default)                                 |
| OSLevel           |            | x   |     | 16#00                                                          | TODO                                                      |
| remote            |            | x   |     | StateChannel                                                   |                                                           |
| operator          |            | x   |     | StateOpAct                                                     |                                                           |
| automatic         |            | x   |     | StateAutAct                                                    |                                                           |
| offline           |            | x   |     | StateOffAct                                                    |                                                           |
| remoteSource      |            | x   |     | SrcChannel                                                     |                                                           |
| internalSourceAct |            | x   |     | SrcIntAct                                                      |                                                           |
| manualSourceAct   |            | x   |     | SrcManAct                                                      |                                                           |
| PermEn            | x          | x   |     | True                                                           | Always Enable, Configure permitIn = 0 if no permits       |
| IntlEn            | x          | x   |     | True                                                           | Always Enable, Configure interlockIn = 0 if no interlocks |
| ProtEn            | x          | x   |     | True                                                           | Always Enable, Configure protectIn = 0 if no protections  |
| Permit            | x          | x   |     | permitIn                                                       |                                                           |
| Interlock         | x          | x   |     | interlockIn                                                    |                                                           |
| Protect           | x          | x   |     | Set: protectIn                                                 | Reset happens inside MTP block                            |
| SafePos           | x          | x   |     | safeOpen                                                       |                                                           |
| SafePosEn         | x          | x   |     | safeHold                                                       |                                                           |
| OpenAut           | x          | x   |     | targetPosition > 0                                             |                                                           |
| CloseAut          | x          | x   |     | NOT OpenAut                                                    |                                                           |
| OpenFbkCalc       | x          | x   |     | simulate OR NOT feedbackOpen                                   | TODO: review logic                                        |
| CloseFbkCalc      | x          | x   |     | simulate OR NOT feedbackClose                                  | TODO: review logic                                        |
| PosFbkCalc        |            |     |     | False                                                          | TODO: review logic                                        |
| fbOpenSimulated   |            | x   |     | (simulate OR NOT hasFbOpen) AND OpenAut for simulateDelay      | if no FbOpen connected then treat it as a simulation      |
| fbCloseSimulated  |            | x   |     | (simulate OR NOT hasFbClose) AND NOT OpenAut for simulateDelay | if no FbClose connected then treat it as a simulation     |
| OpenFbk           | x          | x   |     | feedbackOpen OR fbOpenSimulated                                |                                                           |
| CloseFbk          | x          | x   |     | feedbackClose OR fbCloseSimulated                              |                                                           |
| opened            |            | x   |     | OpenAut AND OpenFbk                                            |                                                           |
| closed            |            | x   |     | NOT OpenAut AND CloseFbk                                       |                                                           |
| ResetAut          | x          | x   |     | reset                                                          |                                                           |
| PosSclMin         | x          | x   |     | scaleMin                                                       |                                                           |
| PosSclMax         | x          | x   |     | scaleMax                                                       |                                                           |
| PosUnit           | x          | x   |     | 0                                                              | Fixed on % (TODO: look up int value for %)                |
| PosMin            | x          | x   |     | PosSclMin                                                      | Make identical to scale                                   |
| PosMax            | x          | x   |     | PosSclMax                                                      | Make identical to scale                                   |
| PosInt            | x          | x   |     | targetPosition                                                 |                                                           |
| PosFbk            | x          | x   |     | feedbackPosition                                               |                                                           |
| positionOut       | x          | x   |     | Pos                                                            |                                                           |
| reset             |            | x   |     | False                                                          | reset = False at the end of the FB                        |
|                   |            |     |     |                                                                |                                                           |
