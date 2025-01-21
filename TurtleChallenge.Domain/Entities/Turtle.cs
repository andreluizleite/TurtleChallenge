using TurtleChallenge.Domain.ValueObjects;

namespace TurtleChallenge.Domain.Entities
{
    public class Turtle
    {
        public Position Position { get; private set; }
        public Direction Direction { get; private set; }

        public Turtle(Position startPosition, Direction startDirection)
        {
            Position = startPosition;
            Direction = startDirection;
        }

        public void Move() => Position = Position.Move(Direction);

        public void Rotate() => Direction = Direction.RotateRight();
    }

}
