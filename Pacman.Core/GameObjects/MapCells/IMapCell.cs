namespace Pacman.Core.GameObjects.MapCells;

public interface IMapCell
{
    void Draw();

    void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove);
}