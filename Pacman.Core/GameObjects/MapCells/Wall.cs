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

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove)
        => onWall(this);

    public override string ToString() => Character;
}