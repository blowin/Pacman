namespace Pacman.Console;

public class GameMap
{
    private const char PlaceToMoveChar = ' ';
    private const char ScoreChar = '.';
    
    private readonly char[,] _map;

    public GameMap(char[,] map)
    {
        _map = map;
    }

    public GameMap(string path) 
        : this(ReadMap(path))
    {
    }

    public bool IsAvailablePointForMovement(int x, int y)
    {
        var cell = _map[x, y];
        return cell == PlaceToMoveChar || cell == ScoreChar;
    }

    public bool IsScore(int x, int y) => _map[x, y] == ScoreChar;

    public void EatScore(int x, int y)
    {
        if (!IsScore(x, y))
            throw new InvalidOperationException("The score is not in this position.");
        _map[x, y] = PlaceToMoveChar;
    }
    
    public void DrawMap()
    {
        for (int y = 0; y < _map.GetLength(1); y++)
        {
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                System.Console.Write(_map[x, y]);
            }
            System.Console.Write("\n");
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