# SolenoidValve

## MTP Interface

[AnaMon](./../MTP/MonBinVlv.md)

## Variable Table

| Variable         | Var Type | Data Type | Default | Description                                                        |
| ---------------- | -------- | --------- | ------- | ------------------------------------------------------------------ |
| MTPBase          | InOut    | MonBinVlv |         |                                                                    |
| id               | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects      |
| open             | Input    | Bool      |         | open command                                                       |
| close            | Input    | Bool      |         | close command                                                      |
| feedbackOpen     | Input    | Bool      | True    | feedback open                                                      |
| feedbackClose    | Input    | Bool      | True    | feedback close                                                     |
| hasFbOpen        | Input    | Bool      |         | has open feedback                                                  |
| hasFbClose       | Input    | Bool      |         | hase close feedback                                                |
| safeOpen         | Input    | Bool      |         | Safe Position Open                                                 |
| safeHold         | Input    | Bool      |         | Holds Position on interlock (priority over safeOpen)               |
| monitor          | Input    | Bool      | True    | Enables errors on the feedback monitoring                          |
| simulate         | Input    | Bool      |         | Enable simulation                                                  |
| simulateDelay    | Input    | Bool      | 1       | Simulated delay to set the feedback signals, in s                  |
| interlockIn      | Input    | Bool      |         | allows control. Does not activate safe position. 0 = no permission |
| permitIn         | Input    | Bool      |         | sets safe position. 0 = interlock active                           |
| protectIn        | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active |
| reset            | Input    | Bool      |         | will try to reset itself                                           |
| remote           | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                             |
| operator         | Output   | Bool      |         | Operator Mode                                                      |
| automatic        | Output   | Bool      |         | Automatic Mode                                                     |
| offline          | Output   | Bool      |         | Offline Mode                                                       |
| error            | Output   | Bool      |         | Any error active                                                   |
| opened           | Output   | Bool      |         | Valve is opened                                                    |
| closed           | Output   | Bool      |         | Valve is closed                                                    |
| fbOpenSimulated  | Local    | Bool      |         | Simulated open feedback                                            |
| fbCloseSimulated | Local    | Bool      |         | Simulated Close feedback                                           |
|                  |          |           |         |                                                                    |
|                  |          |           |         |                                                                    |
|                  |          |           |         |                                                                    |




## Functionality

| Target           | MTP | Expression                                                  | Comment                                                   |
| ---------------- | --- | ----------------------------------------------------------- | --------------------------------------------------------- |
| WQC              | x   | 16#FF                                                       | no QC available (default)                                 |
| OSLevel          |     | TODO                                                        |                                                           |
| remote           |     | StateChannel                                                |                                                           |
| operator         |     | StateOpAct                                                  |                                                           |
| automatic        |     | StateAutAct                                                 |                                                           |
| offline          |     | StateOffAct                                                 |                                                           |
| PermEn           | x   | True                                                        | Always Enable, Configure permitIn = 0 if no permits       |
| IntlEn           | x   | True                                                        | Always Enable, Configure interlockIn = 0 if no interlocks |
| ProtEn           | x   | True                                                        | Always Enable, Configure protectIn = 0 if no protections  |
| Permit           | x   | permitIn                                                    |                                                           |
| Interlock        | x   | interlockIn                                                 |                                                           |
| Protect          | x   | Set: protectIn                                              | Reset happens inside MTP block                            |
| SafePos          | x   | safeOpen                                                    |                                                           |
| MonSafePos       | x   | safeOpen                                                    |                                                           |
| SafePosEn        | x   | safeHold                                                    |                                                           |
| OpenAut          | x   | open                                                        |                                                           |
| CloseAut         | x   | close                                                       |                                                           |
| OpenFbkCalc      | x   | simulation OR NOT feedbackOpen                              |                                                           |
| CloseFbkCalc     | x   | simulation OR NOT feedbackClose                             |                                                           |
| fbOpenSimulated  |     | (simulate OR NOT hasFbOpen) AND Ctrl for simulateDelay      | if no FbOpen connected then treat it as a simulation      |
| fbCloseSimulated |     | (simulate OR NOT hasFbClose) AND NOT Ctrl for simulateDelay | if no FbClose connected then treat it as a simulation     |
| OpenFbk          | x   | feedbackOpen OR fbOpenSimulated                             |                                                           |
| CloseFbk         | x   | feedbackClose OR fbCloseSimulated                           |                                                           |
| opened           |     | Ctrl AND OpenFbk                                            |                                                           |
| closed           |     | NOT Ctrl AND CloseFbk                                       |                                                           |
| ResetAut         | x   | reset                                                       |                                                           |
| MonEn            | x   | monitor                                                     |                                                           |
| reset            |     | False                                                       | reset at the end of the FB                                |


## Todo
