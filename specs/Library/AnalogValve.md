# Analog Valve

## MTP Interface

[MonAnaVlv](./../MTP/MonAnaVlv.md)

## Variable Table

| Variable          | MTP | SCD | Var Type | Data Type | Default | Description                                                               | SCD Name | SCD Terminal Name              |
| ----------------- | --- | --- | -------- | --------- | ------- | ------------------------------------------------------------------------- | -------- | ------------------------------ |
| MTPBase           | x   | x   | InOut    | MonAnaVlv |         |                                                                           |          |                                |
| id                | x   | x   | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects             |          |                                |
| targetPosition    | x   |     | Input    | Real      |         | Target position from program                                              |          |                                |
| feedbackPosition  | x   |     | Input    | Word      |         | Position feedback (0-100%)                                                |          |                                |
| scaleMin          | x   |     | Input    | Real      | 0       | Position scale min                                                        |          |                                |
| scaleMax          | x   |     | Input    | Real      | 100     | Position scale max                                                        |          |                                |
| feedbackOpen      | x   | x   | Input    | Bool      |         | feedback open                                                             | XGH      | Position high feedback         |
| feedbackClose     | x   | x   | Input    | Bool      |         | feedback close                                                            | XGL      | Position low feedback          |
| hasFbOpen         | x   | x   | Input    | Bool      |         | has open feedback                                                         |          |                                |
| hasFbClose        | x   | x   | Input    | Bool      |         | hase close feedback                                                       |          |                                |
| safeOpen          | x   | x   | Input    | Bool      |         | Safe Position is Open                                                     |          |                                |
| enableSafePos     | x   | x   | Input    | Bool      |         | Enable safe position                                                      |          |                                |
| simulate          | x   |     | Input    | Bool      |         | Enable simulation                                                         |          |                                |
| simulateDelay     | x   | x   | Input    | Real      | 1       | Simulated delay to set the feedback signals, in s                         |          |                                |
| interlockIn       | x   |     | Input    | Bool      |         | forces safe position. 1 = interlock active                                |          |                                |
| permitIn          | x   |     | Input    | Bool      | True    | permission to control. Does not activate safe position. 1 = no permission |          |                                |
| protectIn         | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 1 = Protect active        |          |                                |
| reset             | x   |     | Input    | Bool      |         | will try to reset itself                                                  |          |                                |
| positionOutDevice | x   |     | Output   | Word      |         | Position Command to device (0-100%)                                       |          |                                |
| positionOut       | x   |     | Output   | Real      |         | Position Command for use in program                                       |          |                                |
| remote            | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                                |
| operator          | x   |     | Output   | Bool      |         | Operator Mode                                                             |          |                                |
| automatic         | x   |     | Output   | Bool      |         | Automatic Mode                                                            |          |                                |
| offline           | x   |     | Output   | Bool      |         | Offline Mode                                                              |          |                                |
| error             | x   | x   | Output   | Bool      |         | Any error active                                                          | YF       | Function failed                |
| opened            | x   | x   | Output   | Bool      |         | Valve is opened                                                           | BCH      | Output position high confirmed |
| closed            | x   | x   | Output   | Bool      |         | Valve is closed                                                           | BCL      | Output position low confirmed  |
| fbOpenSimulated   | x   | x   | Local    | Bool      |         | Simulated open feedback                                                   |          |                                |
| fbCloseSimulated  | x   | x   | Local    | Bool      |         | Simulated Close feedback                                                  |          |                                |
| selectedPosition  | x   | x   | Local    | Real      |         |                                                                           |          |                                |
| remoteSource      | x   |     | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                    |          |                                |
| internalSourceAct | x   |     | Output   | Bool      |         |                                                                           |          |                                |
| manualSourceAct   | x   |     | Output   | Bool      |         |                                                                           |          |                                |
|                   |     |     |          |           |         |                                                                           |          |                                |

TODO: better description for 'reset' -> now: 'will try to reset itself'?
TODO: is positionOut the command or the actual position? If actual then confusion with position OutDevice because that is the command?

## Functionality

| Target            | MTP signal | MTP | SCD | Expression                                                                           | Comment                                                     |
| ----------------- | ---------- | --- | --- | ------------------------------------------------------------------------------------ | ----------------------------------------------------------- |
| WQC               | x          | x   |     | 16#FF                                                                                | no QC available (default)                                   |
| OSLevel           |            | x   |     | 16#00                                                                                | TODO                                                        |
| remote            |            | x   |     | StateChannel                                                                         |                                                             |
| operator          |            | x   |     | StateOpAct                                                                           |                                                             |
| automatic         |            | x   |     | StateAutAct                                                                          |                                                             |
| offline           |            | x   |     | StateOffAct                                                                          |                                                             |
| remoteSource      |            | x   |     | SrcChannel                                                                           |                                                             |
| internalSourceAct |            | x   |     | SrcIntAct                                                                            |                                                             |
| manualSourceAct   |            | x   |     | SrcManAct                                                                            |                                                             |
| PermEn            | x          | x   |     | True                                                                                 | Always Enable, Configure permitIn = 0 if no permits         |
| IntlEn            | x          | x   |     | True                                                                                 | Always Enable, Configure interlockIn = 0 if no interlocks   |
| ProtEn            | x          | x   |     | True                                                                                 | Always Enable, Configure protectIn = 0 if no protections    |
| Permit            | x          | x   |     | permitIn                                                                             |                                                             |
| Interlock         | x          | x   |     | NOT interlockIn                                                                      | Normalize logic so it's easier to build complex interlocks  |
| Protect           | x          | x   |     | NOT protectIn                                                                        | Set (reset because inverted logic) happens inside MTP block |
| SafePos           | x          | x   |     | safeOpen                                                                             |                                                             |
| SafePosEn         | x          | x   |     | enableSafePos                                                                        |                                                             |
| selectedPosition  |            | x   |     | (PosInt * BOOL_TO_REAL(SrcIntAct)) + (PosMan * BOOL_TO_REAL(SrcManAct))              |                                                             |
| OpenAut           | x          | x   |     | selectedPosition > 0                                                                 |                                                             |
| CloseAut          | x          | x   |     | NOT OpenAut                                                                          |                                                             |
| OpenFbkCalc       | x          | x   |     | simulate OR NOT hasFbOpen                                                            |                                                             |
| CloseFbkCalc      | x          | x   |     | simulate OR NOT hasFbClose                                                           |                                                             |
| PosFbkCalc        | x          |     |     | simulate                                                                             |                                                             |
| fbOpenSimulated   |            | x   |     | OpenFbkCalc AND OpenAut for simulateDelay                                            | if no FbOpen connected then treat it as a simulation        |
| fbCloseSimulated  |            | x   |     | CloseFbkCalc AND NOT OpenAut for simulateDelay                                       | if no FbClose connected then treat it as a simulation       |
| OpenFbk           | x          | x   |     | (feedbackOpen AND NOT OpenFbkCalc) OR (fbOpenSimulated AND OpenFbkCalc)              |                                                             |
| CloseFbk          | x          | x   |     | (feedbackClose AND NOT CloseFbkCalc) OR (fbCloseSimulated AND CloseFbkCalc)          |                                                             |
| opened            |            | x   |     | OpenFbk                                                                              |                                                             |
| closed            |            | x   |     | CloseFbk                                                                             |                                                             |
| ResetAut          | x          | x   |     | reset                                                                                |                                                             |
| PosSclMin         | x          | x   |     | scaleMin                                                                             |                                                             |
| PosSclMax         | x          | x   |     | scaleMax                                                                             |                                                             |
| PosUnit           | x          | x   |     | 0                                                                                    | Fixed on % (TODO: look up int value for %)                  |
| PosMin            | x          | x   |     | PosSclMin                                                                            | Make identical to scale                                     |
| PosMax            | x          | x   |     | PosSclMax                                                                            | Make identical to scale                                     |
| PosInt            | x          | x   |     | targetPosition                                                                       |                                                             |
| PosFbk            | x          | x   |     | (positionOut * BOOL_TO_REAL(simulate)) + (feedbackPosition * BOOL_TO_REAL(simulate)) |                                                             |
| positionOut       | x          | x   |     | Pos                                                                                  |                                                             |
| reset             |            | x   |     | False                                                                                | reset = False at the end of the FB                          |
|                   |            |     |     |                                                                                      |                                                             |
