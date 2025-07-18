# TestDelayedStateMachine

MTP interface for TestDelayedStateMachine function block.

## Variable Table

| Variable | Var Type | Data Type | Description | MTP |
|----------|----------|-----------|-------------|-----|
| Enable | Input | Bool | Enable the state machine | OpMode.StateOpAut |
| Reset | Input | Bool | Reset to initial state | OpMode.StateOffAut |
| StateOutput | Output | Int | Current state number | OpMode.StateAct |
| DelayTime1 | Input | Real | Delay time for first transition (seconds) | DelayParam.V |
| DelayTime2 | Input | Real | Delay time for second transition (seconds) | DelayParam2.V |

## Functionality

| Target | Expression | Comment |
|--------|------------|---------|
| StateOutput | TestState State Machine | |

### TestState State Machine

| State | Actions | Transition Condition | Target |
|-------|---------|---------------------|--------|
| 0 (Idle) | | Enable for DelayTime1 | 1 |
| 1 (Active) | | NOT Enable for DelayTime2 | 2 |
| | | Reset | 0 |
| 2 (Shutdown) | | Reset | 0 |