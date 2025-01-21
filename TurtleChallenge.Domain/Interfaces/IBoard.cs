using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Domain.Interfaces
{
    public interface IBoard
    {
        bool IsOutOfBounds(Position position);
        bool IsMine(Position position);
        bool IsExit(Position position);
    }
}
