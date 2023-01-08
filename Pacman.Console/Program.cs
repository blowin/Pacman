using Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        ConsoleKeyInfo pressedKey = new ConsoleKeyInfo('w', ConsoleKey.W, false, false, false);

        Task.Run(() =>
        {
            while (true)
                pressedKey = Console.ReadKey();
        });

        int pacmanX = 1;
        int pacmanY = 1;
        int score = 0;
        
        while (true)
        {
            Console.Clear();
            
            HandleInput(pressedKey, ref pacmanX, ref pacmanY, map, ref score);
            
            Console.ForegroundColor = ConsoleColor.Blue;
            map.DrawMap();
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(pacmanX, pacmanY);
            Console.Write("@");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(32, 0);
            Console.Write($"Score: {score}");
            
            Thread.Sleep(1000);
        }
    }
    
    private static void HandleInput(ConsoleKeyInfo pressedKey, ref int pacmanX, ref int pacmanY, GameMap map, ref int score)
    {
        var directions = GetDirection(pressedKey);
        var nextPacmanPositionX = pacmanX + directions[0];
        var nextPacmanPositionY = pacmanY + directions[1];

        if (!map.IsAvailablePointForMovement(nextPacmanPositionX, nextPacmanPositionY)) 
            return;
        
        pacmanX = nextPacmanPositionX;
        pacmanY = nextPacmanPositionY;

        if (!map.IsScore(nextPacmanPositionX, nextPacmanPositionY)) 
            return;
        
        score += 1;
        map.EatScore(nextPacmanPositionX, nextPacmanPositionY);
    }
    
    private static int[] GetDirection(ConsoleKeyInfo pressedKey)
    {
        int[] direction = { 0, 0 };
        if (pressedKey.Key == ConsoleKey.UpArrow)
            direction[1] = -1;
        else if (pressedKey.Key == ConsoleKey.DownArrow)
            direction[1] = 1;
        else if (pressedKey.Key == ConsoleKey.LeftArrow)
            direction[0] = -1;
        else if (pressedKey.Key == ConsoleKey.RightArrow)
            direction[0] = 1;
        
        return direction;
    }
}