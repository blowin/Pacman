using Pacman.Core.GameObjects.MapCells;

namespace Pacman.Core.GameObjects;

public class Pacman : IMapCell
{
    private const char PacmanChar = '@';
    
    private bool _alive;

    public IntVector2 Position { get; }

    public Pacman(Pacman root, IntVector2 newPosition)
    {
        _alive = root._alive;
        Position = newPosition;
    }
    
    public Pacman(IntVector2 position)
    {
        Position = position;
        _alive = true;
    }
    
    public void Draw()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(PacmanChar);
        Console.ResetColor();
    }

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove) 
        => throw new NotSupportedException("Unsupported operation for Pacman");

    public void Kill()
    {
        if (!_alive)
            throw new InvalidOperationException("Pacman is dead");
        _alive = false;
    }
}