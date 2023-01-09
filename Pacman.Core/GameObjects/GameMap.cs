using Pacman.Core.GameObjects.MapCells;

namespace Pacman.Core.GameObjects;

public class GameMap : IGameObject
{
    private readonly IMapCell[,] _map;

    private IMapCell this[IntVector2 position]
    {
        get => _map[position.X, position.Y];
        set => _map[position.X, position.Y] = value;
    }
    
    public GameMap(char[,] map)
    {
        var factory = new MapCellFactory();
        _map = factory.Create(map);
    }

    public GameMap(string path) 
        : this(ReadMap(path))
    {
    }

    public bool IsAvailablePointForMovement(IntVector2 position)
    {
        var cell = this[position];
        return cell.Match(wall => false,
            point => true,
            move => true);
    }

    public bool IsScore(IntVector2 position) => this[position].Match(_ => false, point => true, _ => false);

    public void EatScore(IntVector2 position)
    {
        if (!IsScore(position))
            throw new InvalidOperationException("The score is not in this position.");
        this[position] = new PlaceToMove();
    }
    
    public void Update()
    {
        for (int y = 0; y < _map.GetLength(1); y++)
        {
            for (int x = 0; x < _map.GetLength(0); x++)
            {
                _map[x, y].Draw();
            }
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