namespace TurtleChallenge.Domain.ValueObjects
{
    public class Position
    {
        public int X { get; }
        public int Y { get; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Position Move(Direction direction)
        {
            return direction switch
            {
                Direction.North => new Position(X, Y - 1),
                Direction.East => new Position(X + 1, Y),
                Direction.South => new Position(X, Y + 1),
                Direction.West => new Position(X - 1, Y),
                _ => this
            };
        }

        public override bool Equals(object obj)
        {
            return obj is Position pos && pos.X == X && pos.Y == Y;
        }

        public override int GetHashCode() => HashCode.Combine(X, Y);

        public override string ToString() => $"({X}, {Y})";
    }

}
