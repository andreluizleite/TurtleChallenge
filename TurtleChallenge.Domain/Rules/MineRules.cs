using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Rules
{
    public class MineRules : IGameRule
    {
        public GameOutcome Evaluate(Turtle turtle, Board board)
        {
            return board.IsMine(turtle.Position) ? GameOutcome.FailureHitMine : GameOutcome.Incomplete;
        }
    }
}
