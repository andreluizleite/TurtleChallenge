using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Services
{
    public class GameLogic : IGameLogic
    {
        private readonly IBoard _board;

        public GameLogic(IBoard board)
        {
            _board = board;
        }

        public string EvaluateTurtleState(Turtle turtle)
        {
            if (_board.IsOutOfBounds(turtle.Position))
                return "Failure (Out of Bounds)";
            if (_board.IsMine(turtle.Position))
                return $"Failure (Hit Mine at {turtle.Position})";
            if (_board.IsExit(turtle.Position))
                return "Success";

            return "Incomplete";
        }
    }

}
