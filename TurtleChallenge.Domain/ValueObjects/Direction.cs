namespace TurtleChallenge.Domain.ValueObjects
{
    public enum Direction
    {
        North,
        East,
        South,
        West
    }

    public static class DirectionExtensions
    {
        public static Direction RotateRight(this Direction direction)
        {
            return (Direction)(((int)direction + 1) % 4);
        }
    }
    
}
