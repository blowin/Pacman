namespace Pacman.Console.GameObjects;

public class Pacman : IGameObject
{
    private const char PacmanChar = '@';
    
    private IntVector2 _position;

    public IntVector2 Position => _position;
    
    public Pacman(IntVector2 position)
    {
        _position = position;
    }

    public void Update()
    {
        System.Console.ForegroundColor = ConsoleColor.Yellow;
        System.Console.SetCursorPosition(_position.X, _position.Y);
        System.Console.Write(PacmanChar);
    }

    public void MoveTo(IntVector2 position)
    {
        _position = position;
    }
}