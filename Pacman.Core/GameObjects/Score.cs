using Pacman.Core.GameObjects.MapCells;

namespace Pacman.Core.GameObjects;

public class Score : IGameObject
{
    private int _value;
    private readonly IntVector2 _position;

    public Score(GameMap map)
    {
        _position = new IntVector2(map.Width + 1, 0);
        map.OnEatScore += Increase;
    }

    public void Update()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.SetCursorPosition(_position.X, _position.Y);
        Console.Write($"Score: {_value}");
        Console.ResetColor();
    }
    
    private void Increase(ScorePoint point)
    {
        _value += point.Value;
    }
}