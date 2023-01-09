namespace Pacman.Core.GameObjects.MapCells;

public class PlaceToMove : IMapCell
{
    private const string Character = " ";
    
    public void Draw() => Console.Write(Character);

    public TRes Match<TRes>(Func<Wall, TRes> onWall, Func<ScorePoint, TRes> onScorePoint, Func<PlaceToMove, TRes> onPlaceToMove) 
        => onPlaceToMove(this);

    public override string ToString() => Character;
}