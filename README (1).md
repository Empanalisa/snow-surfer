<div align="center">

# 🏂 Snow Surfer

**A 2D snowboarding game built in Unity. Pick a character, ride down the slope, land flips for points and grab powerups on the way to the finish line.**

![Unity](https://img.shields.io/badge/Unity-6000.4-000000?logo=unity&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?logo=csharp&logoColor=white)
![2D](https://img.shields.io/badge/2D-URP-5C5C5C)

</div>

---

## About

Snow Surfer is a side-scrolling snowboarding game. You start on a character select screen, then race down a snowy hill. Tilt your board to land mid-air flips for points, boost for speed, and avoid wiping out. I built it in **Unity 6** with **C#** and the 2D Universal Render Pipeline.

## How to play

1. Choose your rider on the start screen: **Renzo Froggy** or **Solly Rex**.
2. Ride down the slope and reach the finish line.
3. Land flips to build your score.
4. Grab powerups for a temporary speed or spin boost.
5. Crash into the ground and the level restarts. Reaching the finish line restarts it too, so you can play again.

### Controls

| Action | Keyboard | Gamepad |
| --- | --- | --- |
| Spin counter-clockwise | `A` or `←` | Left stick left |
| Spin clockwise | `D` or `→` | Left stick right |
| Boost | `W` or `↑` | Left stick up |

## Features

- **Character select.** The game starts paused on a menu where you pick one of two characters.
- **Flip scoring.** The game tracks how far your rider rotates in the air. Each full flip adds **100 points** to the on-screen score.
- **Speed boost.** Hold up to push the slope's surface speed from the base speed (15) to a boost speed (20).
- **Powerups.** Pickups disappear when you collect them and apply an effect for a limited time:

  | Powerup | Effect | Duration |
  | --- | --- | --- |
  | Short Speed | +10 speed | 2 seconds |
  | Long Speed | +10 speed | 10 seconds |
  | Short Torque | +10 spin power | 3 seconds |

  Powerups are defined as ScriptableObjects, so adding a new one only needs a new asset and no code changes.
- **Particle effects.** There is a snow trail while you ride, crash and finish bursts, and a particle effect while a powerup is active.
- **Crash and finish detection.** Both reload the level after a short delay.

## How it's built

All of the game logic lives in `Assets/Scripts/`:

| Script | What it does |
| --- | --- |
| `PlayerController.cs` | Reads input, applies torque and boost, counts flips and applies powerup effects |
| `CharSelectManager.cs` | Pauses the game on the select screen, then starts it with the chosen character |
| `ScoreManager.cs` | Keeps the score and updates the on-screen text |
| `PowerupSO.cs` | ScriptableObject that defines a powerup's type, strength and duration |
| `PowerupManager.cs` | Handles pickup, then removes the effect when its timer runs out |
| `CrashDetector.cs` | Disables controls and restarts the level when the rider crashes |
| `FinishLine.cs` | Plays the finish effect and restarts the level |
| `SnowTrail.cs` | Plays the snow particles only while the board touches the ground |

**Unity features used:** the Input System package, `Rigidbody2D` physics, `SurfaceEffector2D` for the moving slope, SpriteShape for the terrain, TextMesh Pro for UI text, ScriptableObjects for data and particle systems for effects.

## Getting started

1. Install [Unity Hub](https://unity.com/download) and Unity **6000.4.2f1**.
2. Clone the repo:
   ```bash
   git clone https://github.com/Empanalisa/snow-surfer.git
   ```
3. In Unity Hub, choose **Add → Add project from disk** and select the cloned folder. The first import takes a few minutes.
4. Open `Assets/Scenes/SampleScene` and press **Play**.

## Project structure

```
snow-surfer/
├── Assets/
│   ├── Scripts/       # Gameplay C# scripts
│   ├── Sprites/       # Characters, trees, rocks, clouds and terrain tiles
│   ├── Powerups/      # Powerup ScriptableObject assets
│   ├── Fonts/         # Game font
│   └── Scenes/        # SampleScene (the game level)
├── Packages/          # Unity package manifest
└── ProjectSettings/   # Unity project settings
```
