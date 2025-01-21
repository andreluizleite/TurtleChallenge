using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IGameLogic
    {
        string EvaluateTurtleState(Turtle turtle);
    }
}
