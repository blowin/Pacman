namespace Pacman.Core.GameObjects;

public class Score : IGameObject
{
    private int _value;
    private readonly IntVector2 _position;

    public Score(IntVector2 position)
    {
        _position = position;
    }

    public void Update()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write($"Score: {_value}");
    }
    
    public void Increase()
    {
        _value += 1;
    }
}