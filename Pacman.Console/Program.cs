namespace Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

        Task.Run(() =>
        {
            while (true)
                pressedKey = System.Console.ReadKey();
        });

        var pacman = new Pacman(new IntVector2(1, 1));
        var score = new Score(new IntVector2(32, 0));
        
        while (true)
        {
            System.Console.Clear();
            
            HandleInput(pressedKey, pacman, map, score);
            
            map.Draw();
            pacman.Draw();
            score.Draw();
            
            Thread.Sleep(1000);
        }
    }
    
    private static void HandleInput(ConsoleKeyInfo pressedKey,  Pacman pacman, GameMap map, Score score)
    {
        var directions = GetDirection(pressedKey);
        var nextPacmanPosition = pacman.Position + directions;
        
        if (!map.IsAvailablePointForMovement(nextPacmanPosition)) 
            return;
        
        pacman.MoveTo(nextPacmanPosition);
        
        if (!map.IsScore(nextPacmanPosition)) 
            return;
        
        score.Increase();
        map.EatScore(nextPacmanPosition);
    }
    
    private static IntVector2 GetDirection(ConsoleKeyInfo pressedKey)
    {
        if (pressedKey.Key == ConsoleKey.UpArrow)
            return new IntVector2(0, -1);
        if (pressedKey.Key == ConsoleKey.DownArrow)
            return new IntVector2(0, 1);
        if (pressedKey.Key == ConsoleKey.LeftArrow)
            return new IntVector2(-1, 0);
        if (pressedKey.Key == ConsoleKey.RightArrow)
            return new IntVector2(1, 0);
        return IntVector2.Zero;
    }
}