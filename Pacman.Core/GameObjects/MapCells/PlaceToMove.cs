namespace Pacman.Core.GameObjects.MapCells;

public class PlaceToMove : IMapCell
{
    private const string Character = " ";
    
    public void Draw() => Console.Write(Character);

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove)
        => onPlaceToMove(this);

    public override string ToString() => Character;
}