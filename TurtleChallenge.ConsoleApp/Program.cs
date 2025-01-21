using TurtleChallenge.Application.TurtleChallenge.Application;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Services;
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Infrastructure.FileHandling;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var settingsFilePath = "../../../inputs/game-settings.txt";
            var movesFilePath = "../../../inputs/moves.txt";

            var (board, _) = FileReader.LoadGameSettings(settingsFilePath);
            var moveSequences = FileReader.LoadMoves(movesFilePath);
            var gameLogic = new GameLogic(board);

            Console.WriteLine($"Board: {board.Width} x {board.Height}");
            Console.WriteLine($"Exit point: {board.ExitPoint.X}, {board.ExitPoint.Y}");

            // Simulate each game
            int count = 1;
            foreach (var moveSequence in moveSequences)
            {
                var turtle = new Turtle(new Position(0, 1), Direction.North); 

                var gameSimulator = new GameSimulator(turtle, gameLogic);
                Console.WriteLine($"Sequence {count}: " + gameSimulator.Simulate(moveSequence));
                count++;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
