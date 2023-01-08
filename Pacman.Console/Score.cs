namespace Pacman.Console;

public class Score
{
    private int _value;
    private readonly IntVector2 _position;

    public Score(IntVector2 position)
    {
        _position = position;
    }

    public void Draw()
    {
        System.Console.ForegroundColor = ConsoleColor.Red;
        System.Console.SetCursorPosition(_position.X, _position.Y);
        System.Console.Write($"Score: {_value}");
    }

    public void Increase()
    {
        _value += 1;
    }
}