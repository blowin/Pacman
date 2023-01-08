using Pacman.Console.GameObjects;

namespace Pacman.Console;

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
        System.Console.CursorVisible = false;
        
        _gameObjects = gameObjects;
        _waitTime = waitTime;
    }

    public void Run()
    {
        while (true)
        {
            System.Console.Clear();
           
            foreach (var gameObject in _gameObjects)
                gameObject.Update();
            
            Thread.Sleep(_waitTime);
        }
    }
}