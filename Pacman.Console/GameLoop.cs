using Pacman.Console.GameObjects;

namespace Pacman.Console;

public class GameLoop
{
    private readonly IGameObject[] _gameObjects;
    
    public GameLoop(IGameObject[] gameObjects)
    {
        System.Console.CursorVisible = false;
        
        _gameObjects = gameObjects;
    }

    public void Run()
    {
        while (true)
        {
            foreach (var gameObject in _gameObjects)
                gameObject.Update();
        }
    }
}