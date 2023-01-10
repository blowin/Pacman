namespace Pacman.Core.GameObjects.MapCells;

public class ScorePoint : IMapCell
{
    private const string Character = ".";

    public int Value { get; }
    
    public ScorePoint(int value = 1)
    {
        Value = value;
    }
    
    public void Draw() => Console.Write(Character);

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove)
        => onScorePoint(this);

    public override string ToString() => Character;
}