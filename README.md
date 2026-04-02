# Battleship Console Game

A backend-focused, object-oriented console implementation of the classic Battleship game. Written in C#, this project focuses on clean architecture, utilizing interfaces, inheritance, and the Factory design pattern to manage game state and entity creation. 

## Features

* **Object-Oriented Design:** Implements `IHealth` and `IInfomatic` interfaces across various ship types (Carrier, Battleship, Destroyer, Submarine, Patrol Boat).
* **Factory Pattern:** Uses a `ShipFactory` to parse text files and instantiate ship objects dynamically.
* **Interactive CLI:** Play the game directly from the console using coordinate-based targeting.
* **Custom Game States:** Load custom board configurations via text files.

## Getting Started

### Prerequisites
* [.NET SDK](https://dotnet.microsoft.com/download) installed on your machine.


