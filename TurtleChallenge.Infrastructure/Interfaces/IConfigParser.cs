namespace TurtleChallenge.Infrastructure.Interfaces
{
    public interface IConfigParser<T>
    {
        T Parse(string[] lines);
    }
}
