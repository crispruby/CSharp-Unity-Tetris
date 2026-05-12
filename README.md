# Unity Tetris
A classic Tetris game implemented in Unity using C# scripts. This project demonstrates clean code architecture, input handling, tile-based rendering, and game state management.

## Features ✨
- **Complete Tetris Gameplay**: Piece spawning, movement, rotation, line clearing, and scoring.
- **Wall-Kick System**: Proper rotation with wall-kick tests for all tetromino types.
- **Speed Progression**: Game speed increases as score rises.
- **High Score Tracking**: Persistent high score display.
- **Customizable Controls**: Key bindings configurable in the Unity Inspector.
- **Tilemap Rendering**: Uses Unity's Tilemap system for efficient board rendering.

## How to Play
Tetris is a classic puzzle game where you arrange falling tetromino pieces to clear complete lines. The game ends when pieces reach the top of the board.

### Controls 🎮
Default key bindings (configurable in Piece component):
- **Rotate Left**: Alpha1 (1)
- **Rotate Right**: Alpha3 (3)
- **Hard Drop**: Up Arrow or Space
- **Soft Drop**: Down Arrow or Alpha2 (2)
- **Move Left**: Left Arrow
- **Move Right**: Right Arrow

### Objective
- Clear lines by filling them completely with pieces.
- Score points for each line cleared.
- Game speed increases as your score rises.
- Beat your high score!

### Web Builds 🌐
Play Tetris directly in browser:

- [**Itch Games**](https://captain-garneto.itch.io/tetris-coursera)
- [**Unity Play**](https://play.unity.com/en/games/beea6fba-c7cc-4057-83eb-c0879de89d5a/tetris)
  
## Architecture

### Core Classes
- **`Board.cs`**: Manages the game board, tile placement, line clearing, scoring, and game state.
- **`Piece.cs`**: Handles active piece behavior, input processing, movement, and rotation.
- **`Data.cs`**: Static data container for tetromino shapes, rotation matrices, and wall-kick tables.
- **`Tetromino.cs`**: Defines tetromino types and data structures.

### Key Design Decisions
- **Separation of Concerns**: Board handles state, Piece handles input and movement.
- **Data-Driven Design**: Tetromino data is initialized from shared static arrays.
- **Inspector-Friendly**: Public fields for easy configuration in Unity.
- **Performance**: Uses arrays and direct access for fast lookups.
- **Documentation**: XML comments on public APIs for clarity.

## Setup
1. Open the project in Unity (tested with Unity 2021+).
2. Ensure the scene includes a Board GameObject with Tilemap child.
3. Assign TetrominoData assets in the Board component.
4. Configure digit GameObjects for score display.
5. Run the scene to play.

## Code Quality
- **Clean Code**: Consistent formatting, meaningful names, and comments.
- **Error Handling**: Bounds checking and debug logging for invalid states.
- **Modularity**: Easy to extend with new tetromino types or features.
- **No Hard-Coding**: Constants and configurable fields instead of magic numbers.

## Author 👤
**Daniel Anthony Rozek**

[**Portfolio**](https://crispruby.github.io/), 
[**LinkedIn**](https://www.linkedin.com/in/danielrozek/), 
[**GitHub**](https://github.com/crispruby)

## License 📄
This project is open-source and available for educational and portfolio purposes.
