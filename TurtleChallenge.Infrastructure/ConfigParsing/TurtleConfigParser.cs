using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Infrastructure.Interfaces;

namespace TurtleChallenge.Infrastructure.ConfigParsing
{
    public class TurtleConfigParser : IConfigParser<Turtle>
    {
        public Turtle Parse(string[] lines)
        {
            var startPosition = ParseStartPosition(lines[1]);
            return new Turtle(startPosition.Item1, startPosition.Item2);
        }
        private static Tuple<Position, Direction> ParseStartPosition(string line)
        {
            var startParams = line.Split(',');
            var startPosition = new Position(int.Parse(startParams[0]), int.Parse(startParams[1]));
            var startDirection = Enum.Parse<Direction>(startParams[2]);
            return new Tuple<Position, Direction>(startPosition, startDirection);
        }
    }
}
