using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Tests.Helpers
{
    public static class GameRuleHelper
    {
        public static IGameRule CreateExitRule(Position exitPoint)
        {
            return new GameRule((turtle, board) =>
            {
                if (turtle.Position.Equals(exitPoint))
                    return GameOutcome.Success;
                return GameOutcome.Incomplete;
            });
        }

        public static IGameRule CreateMineRule(IEnumerable<Position> mines)
        {
            return new GameRule((turtle, board) =>
            {
                if (mines.Contains(turtle.Position))
                    return GameOutcome.FailureHitMine;
                return GameOutcome.Incomplete;
            });
        }

        public static IGameRule CreateOutOfBoundsRule()
        {
            return new GameRule((turtle, board) =>
            {
                if (turtle.Position.X < 0 || turtle.Position.Y < 0 ||
                    turtle.Position.X >= board.Width || turtle.Position.Y >= board.Height)
                    return GameOutcome.FailureOutOfBounds;
                return GameOutcome.Incomplete;
            });
        }
    }

    public class GameRule : IGameRule
    {
        private readonly Func<Turtle, Board, GameOutcome> _ruleLogic;

        public GameRule(Func<Turtle, Board, GameOutcome> ruleLogic)
        {
            _ruleLogic = ruleLogic;
        }

        public GameOutcome Evaluate(Turtle turtle, Board board)
        {
            return _ruleLogic(turtle, board);
        }
    }
}
