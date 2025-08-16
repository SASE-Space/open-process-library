# MonBinVlv HMI Specs

## Icon Components

## Faceplate Components

| Component      | Type     |
| -------------- | -------- |
| localButton    | Button   |
| remoteButton   | Button   |
| offlineButton  | Button   |
| manualButton   | Button   |
| autoButton     | Button   |
| closeButton    | Button   |
| openButton     | Button   |
| disableButtons | Variable |
|                |          |


## Faceplate Display Logic

| Target                | Expression / Explanation                                     | Comment |
| --------------------- | ------------------------------------------------------------ | ------- |
| disableButtons        | (isPEA AND StateChannel = 1) OR (isPOL AND StateChannel = 0) |         |
| offlineButton.disable | disableButtons                                               |         |
| manualButton.disable  | disableButtons                                               |         |
| autoButton.disable    | disableButtons                                               |         |
| closeButton.disable   | disableButtons                                               |         |
| openButton.disable    | disableButtons                                               |         |
|                       |                                                              |         |


## Faceplate Action Logic

| Source               | Expression / Explanation | Comment |
| -------------------- | ------------------------ | ------- |
| offlineButton.pushed | SET StateOffOp           |         |
| manualButton.pushed  | SET StateOpOp            |         |
| autoButton.pushed    | SET StateAutOp           |         |
|                      |                          |         |