using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Services;

namespace TurtleChallenge.Application
{
    namespace TurtleChallenge.Application
    {
        public class GameSimulator
        {
            private readonly Turtle _turtle;
            private readonly GameLogic _gameLogic;

            public GameSimulator(Turtle turtle, GameLogic gameLogic)
            {
                _turtle = turtle;
                _gameLogic = gameLogic;
            }

            public string Simulate(IEnumerable<char> moves)
            {
                foreach (var move in moves)
                {
                    if (move == 'r') _turtle.Rotate();
                    else if (move == 'm') _turtle.Move();

                    var result = _gameLogic.EvaluateTurtleState(_turtle);
                    if (result != "Incomplete") return result;
                }

                return "Incomplete";
            }
        }
    }


}
