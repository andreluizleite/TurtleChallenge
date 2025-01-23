
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Infrastructure.Interfaces;

namespace TurtleChallenge.Infrastructure.ConfigParsing
{
    public class BoaringConfigParser : IConfigParser<Board>
    {
        public Board Parse(string[] lines)
        {
            var boardSize = ParseBoardSize(lines[0]);
            var exitPoint = ParseExitPoint(lines[1]);
            var mines = ParseMines(lines.Skip(3));
            return new Board(boardSize.Item1, boardSize.Item2, exitPoint, mines);
        }
        public static Tuple<int, int>ParseBoardSize(string line)
        {
            var boardSize = line.Split('x');
            var boardWidth = int.Parse(boardSize[0]);
            var boardHeight = int.Parse(boardSize[1]);
            return new Tuple<int, int>(boardWidth, boardHeight);
        }
        private static Position ParseExitPoint(string line)
        {
            var exitParams = line.Split(',');
            return new Position(int.Parse(exitParams[0]), int.Parse(exitParams[1]));
        }
        private static List<Position> ParseMines(IEnumerable<string> lines)
        {
            var mines = new List<Position>();
            foreach (var line in lines)
            {
                var mineParams = line.Split(',');
                mines.Add(new Position(int.Parse(mineParams[0]), int.Parse(mineParams[1])));
            }
            return mines;
        }
    }
}
