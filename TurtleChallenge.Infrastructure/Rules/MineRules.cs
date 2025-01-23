using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Infrastructure.Rules
{
    public class MineRules : IGameRule
    {
        public GameOutcome Evaluate(Turtle turtle, Board board)
        {
            return board.IsMine(turtle.Position) ? GameOutcome.FailureHitMine : GameOutcome.Incomplete;
        }
    }
}
