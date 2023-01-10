namespace Pacman.Core.GameObjects;

public class UserInput : IGameObject
{
    private ConsoleKeyInfo _pressedKey;
    private readonly GameMap _map;

    public UserInput(GameMap map)
    {
        _pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
        _map = map;
            
        var _ = Task.Factory.StartNew(() =>
        {
            while (true)
                _pressedKey = Console.ReadKey();
        }, TaskCreationOptions.LongRunning);
    }

    public void Update()
    {
        var direction = GetDirection();
        _map.MovePacman(direction);
    }
        
    private IntVector2 GetDirection()
    {
        return _pressedKey.Key switch
        {
            ConsoleKey.UpArrow => new IntVector2(0, -1),
            ConsoleKey.DownArrow => new IntVector2(0, 1),
            ConsoleKey.LeftArrow => new IntVector2(-1, 0),
            ConsoleKey.RightArrow => new IntVector2(1, 0),
            _ => IntVector2.Zero
        };
    }
}