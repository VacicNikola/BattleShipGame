namespace Battleship.Library
{
    public interface IDifficulty
    {
        void Execute();

    }

    public enum Difficulty { Easy, Medium, Hard};
}