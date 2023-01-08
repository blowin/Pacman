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
        var input = new UserInput(pacman, map, score);

        var gameObjects = new IGameObject[]
        {
            input,
            map,
            pacman,
            score
        };
        
        while (true)
        {
            System.Console.Clear();
           
            foreach (var gameObject in gameObjects)
                gameObject.Update();
            
            Thread.Sleep(1000);
        }
    }
}