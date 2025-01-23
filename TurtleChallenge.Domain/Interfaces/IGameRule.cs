using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IGameRule
    {
        GameOutcome Evaluate(Turtle turtle, Board board);
    }
}
