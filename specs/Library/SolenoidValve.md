# SolenoidValve

## MTP Interface

[MonBinVlv](./../MTP/MonBinVlv.md)




## Variable Table

- MTP: variable available on the MTP-first blocks
- SCD: variable available on the SCD-first blocks          

| Variable         | MTP | SCD | Var Type | Data Type | Default | Description                                                                   | SCD Name | SCD Terminal Name                  |
| ---------------- | --- | --- | -------- | --------- | ------- | ----------------------------------------------------------------------------- | -------- | ---------------------------------- |
| MTPBase          | x   | x   | InOut    | MonBinVlv |         |                                                                               |          |                                    |
| id               | x   | x   | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects                 |          |                                    |
| open             | x   | x   | Input    | Bool      |         | open command from PLC program                                                 | XH       | External set high                  |
| close            | x   | x   | Input    | Bool      |         | close command from PLC program                                                | XL       | External set low                   |
| outsideOpen      | x   | x   | Input    | Bool      |         | open command from local panel                                                 | XOH      | External outside set high          |
| outsideClose     | x   | x   | Input    | Bool      |         | close command from local panel                                                | XOL      | External outside set low           |
| feedbackOpen     | x   | x   | Input    | Bool      | True    | feedback open                                                                 | XGH      | Position high feedback             |
| feedbackClose    | x   | x   | Input    | Bool      | True    | feedback close                                                                | XGL      | Position low feedback              |
| hasFbOpen        | x   | x   | Input    | Bool      |         | has open feedback                                                             |          |                                    |
| hasFbClose       | x   | x   | Input    | Bool      |         | hase close feedback                                                           |          |                                    |
| safeOpen         | x   | x   | Input    | Bool      |         | Safe Position is Open                                                         |          |                                    |
| safeHold         | x   | x   | Input    | Bool      |         | Holds Position on interlock (priority over safeOpen)                          |          |                                    |
| monitor          | x   | x   | Input    | Bool      | True    | Enables errors on the feedback monitoring                                     |          |                                    |
| staticTimeout    | x   | x   | Input    | Real      | 2       | Amount of time before a static monitoring error is triggered                  |          |                                    |
| dynamicTimeout   | x   | x   | Input    | Real      | 5       | Amount of time before a dynamic monitoring error is triggered                 |          |                                    |
| simulate         | x   | x   | Input    | Bool      |         | Enable simulation                                                             |          |                                    |
| simulateDelay    | x   | x   | Input    | Real      | 1       | Simulated delay to set the feedback signals, in s                             |          |                                    |
| interlockIn      | x   |     | Input    | Bool      |         | forces safe position. 0 = interlock active                                    |          |                                    |
| permitIn         | x   |     | Input    | Bool      | 1       | permission to control. Does not activate safe position. 0 = no permission     |          |                                    |
| protectIn        | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active            |          |                                    |
| reset            | x   | x   | Input    | Bool      |         | will try to reset itself TODO: better description                             |          |                                    |
| externalFault    | x   | x   | Input    | Bool      |         | Loop failure-e.g. I/O card broken.                                            | XF       | ExternalFault                      |
| lockOpen         |     | x   | Input    | Bool      |         | locks in open position, and switches to manual mode, subject to blockForcing  | LSH      | Lock safeguarding high             |
| lockClose        |     | x   | Input    | Bool      |         | locks in close position, and switches to manual mode, subject to blockForcing | LSL      | Lock safeguarding low              |
| forceOpen        |     | x   | Input    | Bool      |         | forces open position, no reset needed, subject to blockForcing                | FSH      | Force safeguarding high            |
| forceClose       |     | x   | Input    | Bool      |         | forces open position, no reset needed, subject to blockForcing                | FSL      | Force safeguarding low             |
| disableOpen      |     | x   | Input    | Bool      |         | disable transition to open, subject to blockForcing                           | FDH      | Force disable transition high      |
| disableClose     |     | x   | Input    | Bool      |         | disable transition to close, subject to blockForcing                          | FDL      | Force disable transition low       |
| block            |     | x   | Input    | Bool      |         | lock, force and disables Open/Close will have no effect when active (1)       | FB       | Force blocking                     |
| surpressAlarms   | x   | x   | Input    | Bool      |         | surpresses alarms                                                             | FU       | Force suppression                  |
| setAuto          | x   | x   | Input    | Bool      |         | sets auto mode (TODO: not linked?)                                            | LA       | Lock auto                          |
| setManual        | x   | x   | Input    | Bool      |         | sets manual mode (TODO: not linked?)                                          | LM       | Lock manual                        |
| setOutside       | x   | x   | Input    | Bool      |         | sets outside mode                                                             | LO       | Lock outside                       |
| openCommand      | x   | x   | Output   | Bool      |         | open command to device                                                        | Y        | Normal function output             |
| pulseOpen        | x   | x   | Output   | Bool      |         | one cycle pulse when starting open command                                    | YH       | Pulsed normal function output high |
| pulseClose       | x   | x   | Output   | Bool      |         | one cycle pulse when ending open command                                      | YL       | Pulsed normal function output low  |
| remote           | x   | x   | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                        |          |                                    |
| operator         | x   | x   | Output   | Bool      |         | Operator Mode                                                                 |          |                                    |
| automatic        | x   | x   | Output   | Bool      |         | Automatic Mode                                                                | BA       | Status auto/man                    |
| offline          | x   | x   | Output   | Bool      |         | Offline Mode                                                                  |          |                                    |
| outside          | x   | x   | Output   | Bool      |         | Outside mode                                                                  | BO       | Status outside                     |
| error            | x   | x   | Output   | Bool      |         | Any error active                                                              | YF       | Function failed                    |
| opened           | x   | x   | Output   | Bool      |         | Valve is opened                                                               | BCH      | Output position high confirmed     |
| closed           | x   | x   | Output   | Bool      |         | Valve is closed                                                               | BCL      | Output position low confirmed      |
| fbOpenSimulated  | x   | x   | Local    | Bool      |         | Simulated open feedback                                                       |          |                                    |
| fbCloseSimulated | x   | x   | Local    | Bool      |         | Simulated Close feedback                                                      |          |                                    |
| forceActive      | x   | x   | Output   | Bool      |         | Any forcing or safeguarding active                                            | BS       | Status safeguarding                |
| blocked          |     | x   | Output   | Bool      |         | block active                                                                  | BB       | Status blocked                     |
| surpressed       | x   | x   | Output   | Bool      |         | alarms surpressed                                                             | BU       | Status surpressed                  |
|                  |     |     |          |           |         |                                                                               |          |                                    |







## Functionality

| Target           | MTP signal | MTP | SCD | Expression                                                  | Comment                                                   |
| ---------------- | ---------- | --- | --- | ----------------------------------------------------------- | --------------------------------------------------------- |
| WQC              | x          | x   |     | 16#FF                                                       | no QC available (default)                                 |
| remote           |            | x   |     | StateChannel                                                |                                                           |
| operator         |            | x   |     | StateOpAct                                                  |                                                           |
| automatic        |            | x   |     | StateAutAct                                                 |                                                           |
| offline          |            | x   |     | StateOffAct                                                 |                                                           |
| PermEn           | x          | x   |     | True                                                        | Always Enable, Configure permitIn = 0 if no permits       |
| IntlEn           | x          | x   |     | True                                                        | Always Enable, Configure interlockIn = 0 if no interlocks |
| ProtEn           | x          | x   |     | True                                                        | Always Enable, Configure protectIn = 0 if no protections  |
| Permit           | x          | x   |     | permitIn                                                    |                                                           |
| Interlock        | x          | x   |     | interlockIn                                                 |                                                           |
| Protect          | x          | x   |     | Set: protectIn                                              | Reset happens inside MTP block                            |
| SafePos          | x          | x   |     | safeOpen                                                    |                                                           |
| MonSafePos       | x          | x   |     | safeOpen                                                    |                                                           |
| SafePosEn        | x          | x   |     | safeHold                                                    |                                                           |
| OpenAut          | x          | x   |     | open                                                        |                                                           |
| CloseAut         | x          | x   |     | close                                                       |                                                           |
| OpenFbkCalc      | x          | x   |     | simulate OR NOT feedbackOpen                                | TODO: review logic, probably need to use hasFbOpen        |
| CloseFbkCalc     | x          | x   |     | simulate OR NOT feedbackClose                               | TODO: review logic                                        |
| fbOpenSimulated  |            | x   |     | (simulate OR NOT hasFbOpen) AND Ctrl for simulateDelay      | if no FbOpen connected then treat it as a simulation      |
| fbCloseSimulated |            | x   |     | (simulate OR NOT hasFbClose) AND NOT Ctrl for simulateDelay | if no FbClose connected then treat it as a simulation     |
| OpenFbk          | x          | x   |     | feedbackOpen OR fbOpenSimulated                             |                                                           |
| CloseFbk         | x          | x   |     | feedbackClose OR fbCloseSimulated                           |                                                           |
| opened           |            | x   |     | Ctrl AND OpenFbk                                            |                                                           |
| closed           |            | x   |     | NOT Ctrl AND CloseFbk                                       |                                                           |
| ResetAut         | x          | x   |     | reset                                                       |                                                           |
| MonEn            | x          | x   |     | monitor                                                     |                                                           |
| MonStatTi        | x          | x   |     | staticTimeout                                               |                                                           |
| MonDynTi         | x          | x   |     | dynamicTimeout                                              |                                                           |
| reset            |            | x   |     | False                                                       | reset = False at the end of the FB                        |
|                  |            |     |     |                                                             |                                                           |


## Todo
