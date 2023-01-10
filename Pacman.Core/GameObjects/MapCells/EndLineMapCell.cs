namespace Pacman.Core.GameObjects.MapCells;

public class EndLineMapCell : IMapCell
{
    private readonly IMapCell _wrap;
    
    public EndLineMapCell(IMapCell wrap)
    {
        _wrap = wrap;
    }

    public void Draw()
    {
        _wrap.Draw();
        Console.WriteLine();
    }

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove) 
        => _wrap.Match(onWall, onScorePoint, onPlaceToMove);

    public override string? ToString() => _wrap.ToString();
}