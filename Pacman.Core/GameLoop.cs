using Pacman.Core.GameObjects;

namespace Pacman.Core;

public class GameLoop
{
    private readonly IGameObject[] _gameObjects;
    private readonly TimeSpan _waitTime;
    private readonly GameMap _map;

    public GameLoop(GameMap map, IGameObject[] gameObjects)
        : this(map, gameObjects, TimeSpan.FromSeconds(1))
    {
    }
    
    public GameLoop(GameMap map, IGameObject[] gameObjects, TimeSpan waitTime)
    {
        Console.CursorVisible = false;
        
        _gameObjects = gameObjects;
        _waitTime = waitTime;
        _map = map;
    }

    public void Run()
    {
        while (!_map.EndOfGame)
        {
            Console.Clear();
           
            foreach (var gameObject in _gameObjects)
                gameObject.Update();
            
            Thread.Sleep(_waitTime);
        }
    }
}