using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Infrastructure.ConfigParsing;

namespace TurtleChallenge.Infrastructure.FileHandling
{
    public static class FileReader
    {
        public static (Board, Turtle) LoadGameSettings(string filePath)
        {
            var lines = File.ReadAllLines(filePath);

            var board = new BoaringConfigParser().Parse(lines);
            var turtle = new TurtleConfigParser().Parse(lines);

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
    }

}
