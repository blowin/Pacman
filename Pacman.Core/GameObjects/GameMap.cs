using Pacman.Core.GameObjects.MapCells;

namespace Pacman.Core.GameObjects;

public class GameMap : IGameObject
{
    public event Action<ScorePoint>? OnEatScore; 

    private readonly IMapCell[,] _map;
    private Pacman _pacman;

    public int Height => _map.GetLength(1);
    
    public int Width => _map.GetLength(0);
    
    private IMapCell this[IntVector2 position]
    {
        get => _map[position.X, position.Y];
        set => _map[position.X, position.Y] = value;
    }
    
    public GameMap(char[,] map)
    {
        var factory = new MapCellFactory();
        _map = factory.Create(map);

        var pacmanPosition = new IntVector2(1, 1);
        this[pacmanPosition] = _pacman = new Pacman(pacmanPosition);
    }

    public GameMap(string path) 
        : this(ReadMap(path))
    {
    }
    
    public void Update()
    {
        for (int y = 0; y < Height; y++)
        {
            for (int x = 0; x < Width; x++)
            {
                _map[x, y].Draw();
            }
        }
    }

    public void MovePacman(IntVector2 direction)
    {
        if(direction.Equals(IntVector2.Zero))
            return;

        var newPacmanPosition = _pacman.Position + direction;
        
        var cell = this[newPacmanPosition];
        cell.Match(wall => _pacman.Kill(), point => OnEatScore?.Invoke(point), move => {});
        
        MovePacmanTo(newPacmanPosition);
    }

    private void MovePacmanTo(IntVector2 newPacmanPosition)
    {
        var oldPacmanPosition = _pacman.Position;
        _pacman = new Pacman(_pacman, newPacmanPosition);
        
        this[newPacmanPosition] = _pacman;
        this[oldPacmanPosition] = new PlaceToMove();
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