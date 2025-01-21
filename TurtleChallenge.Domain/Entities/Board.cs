using TurtleChallenge.Domain.Interfaces;
using TurtleChallenge.Domain.ValueObjects;

public class Board : IBoard
{
    public int Width { get; }
    public int Height { get; }
    public Position ExitPoint { get; }
    private readonly HashSet<Position> _mines;

    public Board(int width, int height, Position exitPoint, IEnumerable<Position> mines)
    {
        Width = width;
        Height = height;
        ExitPoint = exitPoint;
        _mines = new HashSet<Position>(mines);
    }

    public bool IsOutOfBounds(Position position)
    {
        return position.X < 0 || position.X >= Width || position.Y < 0 || position.Y >= Height;
    }

    public bool IsMine(Position position) => _mines.Contains(position);

    public bool IsExit(Position position) => position.Equals(ExitPoint);
}
