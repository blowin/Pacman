using Pacman.Core;
using Pacman.Core.GameObjects;

namespace Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        var pacman = new Core.GameObjects.Pacman(new IntVector2(1, 1));
        var score = new Score(new IntVector2(32, 0));
        var input = new UserInput(pacman, map, score);

        var gameLoop = new GameLoop(new IGameObject[]
        {
            input,
            map,
            pacman,
            score
        }, TimeSpan.FromSeconds(1));
        gameLoop.Run();
    }
}