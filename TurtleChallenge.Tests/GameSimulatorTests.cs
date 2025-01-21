using TurtleChallenge.Application.TurtleChallenge.Application;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Services;
using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Tests
{
    public class GameSimulatorTests
    {
        [Fact]
        public void Simulate_ShouldReturnSuccess_WhenTurtleReachesExit()
        {
            // Arrange
            var startPosition = new Position(0, 1); // Start position
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2); // Exit point
            var mines = new List<Position> { new Position(1, 1) }; //mine location
            var board = new Board(5, 4, exitPoint, mines); 
            var turtle = new Turtle(startPosition, startDirection);

            var gameLogic = new GameLogic(board);

            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'm', 'm', 'm', 'r', 'm', 'm' }; 

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal("Success", result);
        }

        [Fact]
        public void Simulate_ShouldReturnFailure_WhenTurtleHitsMine()
        {
            // Arrange
            var startPosition = new Position(0, 1);
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2);
            var mines = new List<Position> { new Position(1, 1) };
            var board = new Board(5, 4, exitPoint, mines);
            var turtle = new Turtle(startPosition, startDirection);

            var gameLogic = new GameLogic(board);

            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'r', 'm' }; // Moves that hit the mine

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal("Failure (Hit Mine at (1, 1))", result); 
        }

        [Fact]
        public void Simulate_ShouldReturnIncomplete_WhenTurtleDoesNotReachExit()
        {
            // Arrange
            var startPosition = new Position(0, 1);
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2);
            var mines = new List<Position> { new Position(1, 1) };
            var board = new Board(5, 4, exitPoint, mines); 
            var turtle = new Turtle(startPosition, startDirection);

            var gameLogic = new GameLogic(board);

            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'r' }; // Moves that don't reach the exit

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal("Incomplete", result);
        }

        [Fact]
        public void Simulate_ShouldReturnIncomplete_WhenTurtleOutOfBounds()
        {
            // Arrange
            var startPosition = new Position(0, 1);
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2);
            var mines = new List<Position> { new Position(1, 1) };
            var board = new Board(5, 4, exitPoint, mines);
            var turtle = new Turtle(startPosition, startDirection);

            var gameLogic = new GameLogic(board);

            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'm' }; // Moves that is out of bounds

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal("Failure (Out of Bounds)", result);
        }
    }
}