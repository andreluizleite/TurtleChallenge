using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Enums;
using TurtleChallenge.Domain.Interfaces;

namespace TurtleChallenge.Domain.Services
{
    public class GameLogic : IGameLogic
    {
        private readonly IEnumerable<IGameRule> _rules;
        private readonly Board _board;

        public GameLogic(IEnumerable<IGameRule> rules, Board board)
        {
            _rules = rules;
            _board = board;
        }

        public GameOutcome EvaluateTurtleState(Turtle turtle)
        {
          foreach (var rule in _rules)
          {
                GameOutcome result = rule.Evaluate(turtle, _board);
                if(result != GameOutcome.Incomplete)
                    return result;
          }
            return GameOutcome.Incomplete;
        }
    }

}
