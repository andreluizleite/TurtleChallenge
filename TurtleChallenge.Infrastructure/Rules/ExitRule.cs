using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Infrastructure.Rules
{
    public class ExitRule : IGameRule
    {
        public GameOutcome Evaluate(Turtle turtle, Board board)
        {
            return board.IsExit(turtle.Position) ? GameOutcome.Success : GameOutcome.Incomplete;
        }
    }
}
