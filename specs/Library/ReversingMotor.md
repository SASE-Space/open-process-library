# Reversing Motor

## MTP Interface

[AnaMon](./../MTP/MonBinDrv.md)

## Variable Table

| Variable        | MTP | SCD | Var Type | Data Type | Description                         | SCD Name | SCD Terminal Name |
| --------------- | --- | --- | -------- | --------- | ----------------------------------- | -------- | ----------------- |
| MTPBase         | x   | x   | InOut    | MonBinDrv |                                     |          |                   |
| forward         | x   |     | Input    | Bool      | Forward command from program        |          |                   |
| reverse         | x   |     | Input    | Bool      | Reverse command from program        |          |                   |
| forwardFeedback | x   |     | Input    | Bool      | Forward feedback signal from device |          |                   |
| reverseFeedback | x   |     | Input    | Bool      | Reverse feedback signal from device |          |                   |
| forwardCommand  | x   |     | Output   | Bool      | Forward command to device           |          |                   |
| reverseCommad   | x   |     | Output   | Bool      | Reverse command to device           |          |                   |
| forwardActive   | x   |     | Output   | Bool      | Motor running forward               |          |                   |
| reverseActive   | x   |     | Output   | Bool      | Motor running reverse               |          |                   |

