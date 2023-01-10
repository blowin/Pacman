using Pacman.Core;
using Pacman.Core.GameObjects;

namespace Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        var score = new Score(map);
        var input = new UserInput(map);

        var gameLoop = new GameLoop(new IGameObject[]
        {
            input,
            map,
            score
        }, TimeSpan.FromSeconds(1));
        gameLoop.Run();
    }
}