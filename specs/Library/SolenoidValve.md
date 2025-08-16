# SolenoidValve

## MTP Interface

[AnaMon](./../MTP/MonBinVlv.md)




## Variable Table

- MTP: variable available on the MTP-first blocks
- SCD: variable available on the SCD-first blocks          

| Variable         | MTP | SCD | Var Type | Data Type | Default | Description                                                                   | SCD Name | SCD Terminal Name                  |
| ---------------- | --- | --- | -------- | --------- | ------- | ----------------------------------------------------------------------------- | -------- | ---------------------------------- |
| MTPBase          | x   | x   | InOut    | MonBinVlv |         |                                                                               |          |                                    |
| id               | x   | x   | Input    | Int       |         | unique project-wide ID to uniquely identify and track objects                 |          |                                    |
| open             | x   | x   | Input    | Bool      |         | open command                                                                  | XH       | External set high                  |
| close            | x   | x   | Input    | Bool      |         | close command                                                                 | XL       | External set low                   |
| outsideOpen      | x   | x   | Input    | Bool      |         | open command from local panel                                                 | XOH      | External outside set high          |
| outsideClose     | x   | x   | Input    | Bool      |         | close command from local panel                                                | XOL      | External outside set low           |
| feedbackOpen     | x   | x   | Input    | Bool      | True    | feedback open                                                                 | XGH      | Position high feedback             |
| feedbackClose    | x   | x   | Input    | Bool      | True    | feedback close                                                                | XGL      | Position low feedback              |
| hasFbOpen        | x   | x   | Input    | Bool      |         | has open feedback                                                             |          |                                    |
| hasFbClose       | x   | x   | Input    | Bool      |         | hase close feedback                                                           |          |                                    |
| safeOpen         | x   | x   | Input    | Bool      |         | Safe Position is Open                                                         |          |                                    |
| safeHold         | x   | x   | Input    | Bool      |         | Holds Position on interlock (priority over safeOpen)                          |          |                                    |
| monitor          | x   | x   | Input    | Bool      | True    | Enables errors on the feedback monitoring                                     |          |                                    |
| simulate         | x   | x   | Input    | Bool      |         | Enable simulation                                                             |          |                                    |
| simulateDelay    | x   | x   | Input    | Bool      | 1       | Simulated delay to set the feedback signals, in s                             |          |                                    |
| interlockIn      | x   |     | Input    | Bool      |         | forces safe position. 0 = interlock active                                    |          |                                    |
| permitIn         | x   |     | Input    | Bool      | 1       | permission to control. Does not activate safe position. 0 = no permission     |          |                                    |
| protectIn        | x   |     | Input    | Bool      |         | Protect, sets safe position, sets protectState. 0 = Protect active            |          |                                    |
| reset            | x   | x   | Input    | Bool      |         | will try to reset itself                                                      |          |                                    |
| externalFault    | x   | x   | Input    | Bool      |         | Loop failure-e.g. I/O card broken.                                            | XF       | ExternalFault                      |
| lockOpen         |     | x   | Input    | Bool      |         | locks in open position, and switches to manual mode, subject to blockForcing  | LSH      | Lock safeguarding high             |
| lockClose        |     | x   | Input    | Bool      |         | locks in close position, and switches to manual mode, subject to blockForcing | LSL      | Lock safeguarding low              |
| forceOpen        |     | x   | Input    | Bool      |         | forces open position, no reset needed, subject to blockForcing                | FSH      | Force safeguarding high            |
| forceClose       |     | x   | Input    | Bool      |         | forces open position, no reset needed, subject to blockForcing                | FSL      | Force safeguarding low             |
| disableOpen      |     | x   | Input    | Bool      |         | disable transition to open, subject to blockForcing                           | FDH      | Force disable transition high      |
| disableClose     |     | x   | Input    | Bool      |         | disable transition to close, subject to blockForcing                          | FDL      | Force disable transition low       |
| block            |     | x   | Input    | Bool      |         | lock, force and disables Open/Close will have no effect when active (1)       | FB       | Force blocking                     |
| surpressAlarms   | x   | x   | Input    | Bool      |         | surpresses alarms                                                             | FU       | Force suppression                  |
| setAuto          | x   | x   | Input    | Bool      |         | sets auto mode                                                                | LA       | Lock auto                          |
| setManual        | x   | x   | Input    | Bool      |         | sets manual mode                                                              | LM       | Lock manual                        |
| setOutside       | x   | x   | Input    | Bool      |         | sets outside mode                                                             | LO       | Lock outside                       |
| openCommand      | x   | x   | Output   | Bool      |         | open command to device                                                        | Y        | Normal function output             |
| pulseOpen        | x   | x   | Output   | Bool      |         | one cycle pulse when starting open command                                    | YH       | Pulsed normal function output high |
| pulseClose       | x   | x   | Output   | Bool      |         | one cycle pulse when ending open command                                      | YL       | Pulsed normal function output low  |
| remote           | x   | x   | Output   | Bool      |         | 0: operator/local, 1: automatic/remote                                        |          |                                    |
| operator         | x   | x   | Output   | Bool      |         | Operator Mode                                                                 |          |                                    |
| automatic        | x   | x   | Output   | Bool      |         | Automatic Mode                                                                | BA       | Status auto/man                    |
| offline          | x   | x   | Output   | Bool      |         | Offline Mode                                                                  | BO       | Status outside                     |
| outside          | x   | x   | Output   | Boold     |         | Outside mode                                                                  |          |                                    |
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
