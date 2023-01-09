namespace Pacman.Core.GameObjects;

public class UserInput : IGameObject
{
    private ConsoleKeyInfo _pressedKey;
    private readonly Pacman _pacman;
    private readonly GameMap _map;
    private readonly Score _score;

    public UserInput(Pacman pacman, GameMap map, Score score)
    {
        _pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);
        _pacman = pacman;
        _map = map;
        _score = score;
            
        var _ = Task.Factory.StartNew(() =>
        {
            while (true)
                _pressedKey = Console.ReadKey();
        }, TaskCreationOptions.LongRunning);
    }

    public void Update()
    {
        var directions = GetDirection();
        var nextPacmanPosition = _pacman.Position + directions;
        
        if (!_map.IsAvailablePointForMovement(nextPacmanPosition)) 
            return;
        
        _pacman.MoveTo(nextPacmanPosition);
        
        if (!_map.IsScore(nextPacmanPosition)) 
            return;
        
        _score.Increase();
        _map.EatScore(nextPacmanPosition);
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