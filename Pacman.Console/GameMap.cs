namespace Pacman.Console;

public class GameMap
{
    private const char PlaceToMoveChar = ' ';
    private const char ScoreChar = '.';
    
    private readonly char[,] _map;

    private char this[IntVector2 position]
    {
        get => _map[position.X, position.Y];
        set => _map[position.X, position.Y] = value;
    }
    
    public GameMap(char[,] map)
    {
        _map = map;
    }

    public GameMap(string path) 
        : this(ReadMap(path))
    {
    }

    public bool IsAvailablePointForMovement(IntVector2 position)
    {
        var cell = this[position];
        return cell == PlaceToMoveChar || cell == ScoreChar;
    }

    public bool IsScore(IntVector2 position) => this[position] == ScoreChar;

    public void EatScore(IntVector2 position)
    {
        if (!IsScore(position))
            throw new InvalidOperationException("The score is not in this position.");
        this[position] = PlaceToMoveChar;
    }
    
    public void Draw()
    {
        System.Console.ForegroundColor = ConsoleColor.Blue;
        for (int y = 0; y < _map.GetLength(1); y++)
        {
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                System.Console.Write(_map[x, y]);
            }
            System.Console.WriteLine();
        }
    }
    
    private static char[,] ReadMap(string path)
    {
        string[] file = File.ReadAllLines(path);
        
        char[,] map = new char[GetMaxLengthOfRow(file), file.Length];

        for (int x = 0; x < map.GetLength(0); x++)
        {
            for (int y = 0; y < map.GetLength(1); y++)
            {
                map[x, y] = file[y][x];
            }   
        }

        return map;
    }
    
    private static int GetMaxLengthOfRow(string[] lines) => lines.Select(e => e.Length).Max();
}