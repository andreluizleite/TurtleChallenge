using TurtleChallenge.Application.TurtleChallenge.Application;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.Services;
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Tests.Helpers;
using Xunit;

namespace TurtleChallenge.Tests
{
    public class GameSimulatorTests
    {
        [Fact]
        public void Simulate_ShouldReturnSuccess_WhenTurtleReachesExit()
        {
            // Arrange
            var startPosition = new Position(0, 1);
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2);
            var mines = new List<Position> { new Position(1, 1) };
            var board = new Board(5, 4, exitPoint, mines);
            var turtle = new Turtle(startPosition, startDirection);

            var rules = new List<IGameRule>
            {
                GameRuleHelper.CreateExitRule(exitPoint),
                GameRuleHelper.CreateMineRule(mines),
                GameRuleHelper.CreateOutOfBoundsRule()
            };

            var gameLogic = new GameLogic(rules, board);
            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'm', 'm', 'm', 'r', 'm', 'm' };

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal(GameOutcome.Success, result);
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

            var rules = new List<IGameRule>
            {
                GameRuleHelper.CreateExitRule(exitPoint),
                GameRuleHelper.CreateMineRule(mines),
                GameRuleHelper.CreateOutOfBoundsRule()
            };

            var gameLogic = new GameLogic(rules, board);
            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'r', 'm' };

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal(GameOutcome.FailureHitMine, result);
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

            var rules = new List<IGameRule>
            {
                GameRuleHelper.CreateExitRule(exitPoint),
                GameRuleHelper.CreateMineRule(mines),
                GameRuleHelper.CreateOutOfBoundsRule()
            };

            var gameLogic = new GameLogic(rules, board);
            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'r', 'm', 'r' };

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal(GameOutcome.Incomplete, result);
        }

        [Fact]
        public void Simulate_ShouldReturnFailure_WhenTurtleOutOfBounds()
        {
            // Arrange
            var startPosition = new Position(0, 1);
            var startDirection = Direction.North;
            var exitPoint = new Position(4, 2);
            var mines = new List<Position> { new Position(1, 1) };
            var board = new Board(5, 4, exitPoint, mines);
            var turtle = new Turtle(startPosition, startDirection);

            var rules = new List<IGameRule>
            {
                GameRuleHelper.CreateExitRule(exitPoint),
                GameRuleHelper.CreateMineRule(mines),
                GameRuleHelper.CreateOutOfBoundsRule()
            };

            var gameLogic = new GameLogic(rules, board);
            var simulator = new GameSimulator(turtle, gameLogic);
            var moves = new List<char> { 'm', 'm' };

            // Act
            var result = simulator.Simulate(moves);

            // Assert
            Assert.Equal(GameOutcome.FailureOutOfBounds, result);
        }
    }
}
