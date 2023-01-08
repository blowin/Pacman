using Pacman.Console.GameObjects;

namespace Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        var pacman = new GameObjects.Pacman(new IntVector2(1, 1));
        var score = new Score(new IntVector2(32, 0));

        var gameLoop = new GameLoop(new IGameObject[]
        {
            new ClearConsole(),
            new UserInput(pacman, map, score),
            map,
            pacman,
            score,
            new ThreadWait(TimeSpan.FromSeconds(1))
        });
        gameLoop.Run();
    }
}