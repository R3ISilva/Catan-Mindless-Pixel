# Code Structure/Design/Architecture

## Prefabs Structure
* Parent = Empty Object (attach controller/logic)
  * Child = Graphics
   * Sprites
  
## Input Script 
We use a package - "Input System" (see CodeMonkey 4min video)

We use a Input Script to handle all input, ex:

*We would call this function from the player script, and set it like this:*

```transform.position = GetPlayerMovementNormalized();```

## Naming Conventions

* Functions: GetPlayerMovementNormalized();
* Variables : playerMovementNormalized;
* Constants: MAXPLAYERMOVEMENT;
* Scripts = Same name as the Prefab;




