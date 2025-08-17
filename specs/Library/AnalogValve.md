# Analog Valve

## MTP Interface

[AnaMon](./../MTP/MonAnaVlv.md)

## Variable Table

| Variable         | MTP | SCD | Var Type | Data Type | Description                  | SCD Name | SCD Terminal Name |
| ---------------- | --- | --- | -------- | --------- | ---------------------------- | -------- | ----------------- |
| MTPBase          | x   | x   | InOut    | MonAnaVlv |                              |          |                   |
| targetPosition   | x   |     | Input    | Real      | Target position from program |          |                   |
| feedbackPosition | x   |     | Input    | Word      | Position feedback (0-100%)   |          |                   |
| simulate         | x   |     | Input    | Bool      | Enable simulation            |          |                   |
| deviceCommand    | x   |     | Output   | Word      | Command to device (0-100%)   |          |                   |
| command          | x   |     | Output   | Real      | Command for use in program   |          |                   |
|                  |     |     |          |           |                              |          |                   |


## Functionality

| Target    | MTP signal | MTP | SCD | Expression   | Comment                   |
| --------- | ---------- | --- | --- | ------------ | ------------------------- |
| WQC       | x          | x   |     | 16#FF        | no QC available (default) |
| OSLevel   |            | x   |     | TODO         |                           |
| OSLevel   |            | x   |     | TODO         |                           |
| remote    |            | x   |     | StateChannel |                           |
| operator  |            | x   |     | StateOpAct   |                           |
| automatic |            | x   |     | StateAutAct  |                           |
| offline   |            | x   |     | StateOffAct  |                           |
|           |            |     |     |              |                           |