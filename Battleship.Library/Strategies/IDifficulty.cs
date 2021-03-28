namespace Battleship.Library
{
    public interface IDifficulty
    {
        string Execute(MyGrid s);

    }

    public enum Difficulty { Easy, Medium, Hard};
}