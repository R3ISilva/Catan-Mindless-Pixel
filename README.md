# Code Structure/Design/Architecture

## Prefabs Structure
* Parent = Empty Object (attach controller/logic)
  * Childs = Graphics
  
## Input Script
We use a Input Script to handle all input, ex:

*We would call this function from the player script, and set it like this:*

```transform.position = GetPlayerMovementNormalized();```

## Naming Conventions

* Functions: GetPlayerMovementNormalized();
* Variables : playerMovementNormalized;
* Constants: MAXPLAYERMOVEMENT;
* Scripts = Same name as the Prefab;




