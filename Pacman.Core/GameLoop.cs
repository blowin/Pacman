using Pacman.Core.GameObjects;

namespace Pacman.Core;

public class GameLoop
{
    private readonly IGameObject[] _gameObjects;
    private readonly TimeSpan _waitTime;

    public GameLoop(IGameObject[] gameObjects)
        : this(gameObjects, TimeSpan.FromSeconds(1))
    {
    }
    
    public GameLoop(IGameObject[] gameObjects, TimeSpan waitTime)
    {
        Console.CursorVisible = false;
        
        _gameObjects = gameObjects;
        _waitTime = waitTime;
    }

    public void Run()
    {
        while (true)
        {
            Console.Clear();
           
            foreach (var gameObject in _gameObjects)
                gameObject.Update();
            
            Thread.Sleep(_waitTime);
        }
    }
}