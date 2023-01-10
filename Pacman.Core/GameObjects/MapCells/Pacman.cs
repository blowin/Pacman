namespace Pacman.Core.GameObjects.MapCells;

public class Pacman : IMapCell
{
    private const char PacmanAliveChar = '@';
    private const char PacmanDeadChar = 'X';
    
    public bool Alive { get; private set; }
    public IntVector2 Position { get; }

    public Pacman(Pacman root, IntVector2 newPosition)
    {
        Alive = root.Alive;
        Position = newPosition;
    }
    
    public Pacman(IntVector2 position)
    {
        Position = position;
        Alive = true;
    }
    
    public void Draw()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.Write(Alive ? PacmanAliveChar : PacmanDeadChar);
        Console.ResetColor();
    }

    public void Match(Action<Wall> onWall, Action<ScorePoint> onScorePoint, Action<PlaceToMove> onPlaceToMove, Action<Pacman> onPacman) 
        => onPacman(this);

    public void Kill()
    {
        if (!Alive)
            throw new InvalidOperationException("Pacman is dead");
        Alive = false;
    }
}