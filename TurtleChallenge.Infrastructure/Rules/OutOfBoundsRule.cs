using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Infrastructure.Rules
{
    public class OutOfBoundsRule : IGameRule
    {
        public GameOutcome Evaluate(Turtle turtle, Board board)
        {
            return board.IsOutOfBounds(turtle.Position) ? GameOutcome.FailureOutOfBounds : GameOutcome.Incomplete;
        }
    }
}
