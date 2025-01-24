using TurtleChallenge.Application.TurtleChallenge.Application;
using TurtleChallenge.Domain.Entities;
using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.Services;
using TurtleChallenge.Domain.ValueObjects;
using TurtleChallenge.Infrastructure.FileHandling;
using TurtleChallenge.Domain.Rules;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Default file paths
            var applicationBasePath = AppDomain.CurrentDomain.BaseDirectory;
            var defaultInputPath = Path.Combine(applicationBasePath, "..", "..", "..", "inputs");
            var defaultSettingsFilePath = "game-settings.txt";
            var defaultMovesFilePath = "moves.txt";

            // Use passed arguments or default files
            var settingsFilePath = args.Length > 0 ? args[0] : defaultSettingsFilePath;
            var movesFilePath = args.Length > 1 ? args[1] : defaultMovesFilePath;

            settingsFilePath = Path.Combine(defaultInputPath, defaultSettingsFilePath);
            movesFilePath = Path.Combine(defaultInputPath, defaultMovesFilePath);

            Console.WriteLine($"Using settings file: {settingsFilePath}");
            Console.WriteLine($"Using moves file: {movesFilePath}");

            // Load game settings and moves
            var (board, _) = FileReader.LoadGameSettings(settingsFilePath);
            var moveSequences = FileReader.LoadMoves(movesFilePath);

            var rules = new List<IGameRule>
            {
                new ExitRule(),
                new MineRules(),
                new OutOfBoundsRule()
            };

            var gameLogic = new GameLogic(rules, board);

            // Display board information
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
