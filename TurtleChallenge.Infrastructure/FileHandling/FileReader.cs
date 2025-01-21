using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Infrastructure.FileHandling
{
    public static class FileReader
    {
        public static (Board, Turtle) LoadGameSettings(string filePath)
        {
            var lines = File.ReadAllLines(filePath);
            var boardSize = ParseBoardSize(lines[0]);
            var startPosition = ParseStartPosition(lines[1]);
            var exitPoint = ParseExitPoint(lines[2]);
            var mines = ParseMines(lines.Skip(3));

            var board = new Board(boardSize.Item1, boardSize.Item2, exitPoint, mines);
            var turtle = new Turtle(startPosition.Item1, startPosition.Item2);

            return (board, turtle);
        }
        public static List<List<char>> LoadMoves(string filePath)
        {
            var lines = File.ReadAllLines(filePath)
                            .Where(line => !string.IsNullOrWhiteSpace(line)) 
                            .ToList();

            var moveList = lines.Select(line => line.Trim()
                                                     .Replace("\n", "")
                                                     .Replace("\r", "")
                                                     .ToList())
                                .ToList();

            return moveList;
        }



        #region Parsing Helpers

        private static Tuple<int, int> ParseBoardSize(string line)
        {
            var boardSize = line.Split('x');
            var boardWidth = int.Parse(boardSize[0]);
            var boardHeight = int.Parse(boardSize[1]);
            return new Tuple<int, int>(boardWidth, boardHeight);
        }

        private static Tuple<Position, Direction> ParseStartPosition(string line)
        {
            var startParams = line.Split(',');
            var startPosition = new Position(int.Parse(startParams[0]), int.Parse(startParams[1]));
            var startDirection = Enum.Parse<Direction>(startParams[2]);
            return new Tuple<Position, Direction>(startPosition, startDirection);
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

        #endregion
    }

}
