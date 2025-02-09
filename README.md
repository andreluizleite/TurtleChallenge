# TurtleChallenge
Author: Andre Leite  
Date: 21/01/2025  

## Overview
This program simulates a turtle navigating a grid based on game settings and move sequences.

## File Structure

- `game-settings.txt`: Board size, starting position, exit point, and mines.
- `moves.txt`: Move sequences for the turtle to follow.

## File Format

### game-settings.txt
5x4 # Board size 0,1,North # Starting position 4,2 # Exit point 1,1 # Mine

### moves.txt
m,r,m,m,m m,r,m,r,m m,m


## How to Run

### Default Files:
1. Put `game-settings.txt` and `moves.txt` in the `inputs` folder.
2. Run:

```bash
dotnet run
or
dotnet run custom-game-settings.txt custom-moves.txt
