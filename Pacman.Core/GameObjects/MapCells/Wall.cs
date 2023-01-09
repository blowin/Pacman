namespace Pacman.Core.GameObjects.MapCells;

public class Wall : IMapCell
{
    private const string Character = "#";

    public void Draw()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.Write(Character);
        Console.ResetColor();
    }

    public TRes Match<TRes>(Func<Wall, TRes> onWall, Func<ScorePoint, TRes> onScorePoint,
        Func<PlaceToMove, TRes> onPlaceToMove)
        => onWall(this);

    public override string ToString() => Character;
}