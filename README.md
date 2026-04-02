# Battleship Console Game

A backend-focused, object-oriented console implementation of the classic Battleship game. Written in C#, this project focuses on clean architecture, utilizing interfaces, inheritance, and the Factory design pattern to manage game state and entity creation. 

## Features

* **Object-Oriented Design:** Implements `IHealth` and `IInfomatic` interfaces across various ship types (Carrier, Battleship, Destroyer, Submarine, Patrol Boat).
* **Factory Pattern:** Uses a `ShipFactory` to parse text files and instantiate ship objects dynamically.
* **Interactive CLI:** Play the game directly from the console using coordinate-based targeting.
* **Robust Validation:** Includes comprehensive test data to validate edge cases, out-of-bounds positioning, and invalid formatting.

## Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.
* Visual Studio 2022 (optional, but recommended for opening the `.sln` file).

### Installation & Execution
1. Clone the repository:
   ```bash
   git clone https://github.com/ASA-Projects/BattleShip-Project.git
   ```
2. Navigate to the project directory where the `.csproj` is located:
   ```bash
   cd BattleShip-Project/BattleshipArifov
   ```
3. Run the application:
   ```bash
   dotnet run
   ```

## Test Data & Configuration

The game populates the board by reading a text file. The repository includes a `TestData` folder containing various scenarios to test the robust parsing of the `ShipFactory`:

* **Good Data:** * `Battleship-GoodData.gameboard.txt`
  * `Battleship-GoodData-Duplicate.gameboard.txt`
  * `Battleship-GoodData-Missing.gameboard.txt`
* **Bad Data (Error Handling):** * `Battleship-BadData-Edge01.gameboard.txt`
  * `Battleship-BadData-Edge02.gameboard.txt`
  * `Battleship-BadData-NegativePosition.gameboard.txt`
  * `Battleship-BadData-TooLong.gameboard.txt`

### Configuration File Format
* Lines starting with `#` are treated as comments and ignored.
* Ship definitions must follow this exact regular expression pattern: `Name, length, direction, x position, y position`

**Parameters:**
* **Name:** Carrier, Battleship, Destroyer, Submarine, or Patrol Boat
* **Length:** Integer (must match the ship type and be ≤ 6)
* **Direction:** `v` (vertical) or `h` (horizontal)
* **X / Y:** Integer coordinates (0-9 for a standard 10x10 grid)

## How to Play

Once the game is running and a valid ship file is loaded, interact with the game using the following commands:

* **`x,y`** : Enter coordinates to fire at a location (e.g., `4,5`). The game will notify you if a ship is hit and when all ships are destroyed.
* **`info`** : Displays the current status of all ships on the board, including their max health, current health, position, and whether they have been destroyed.
* **`exit`** : Quits the game.
