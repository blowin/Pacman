namespace Pacman.Core.GameObjects.MapCells;

public interface IMapCell
{
    void Draw();

    TRes Match<TRes>(Func<Wall, TRes> onWall, Func<ScorePoint, TRes> onScorePoint,
        Func<PlaceToMove, TRes> onPlaceToMove);
}