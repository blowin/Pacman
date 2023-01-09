namespace Pacman.Core.GameObjects.MapCells;

public sealed class MapCellFactory
{
    public IMapCell[,] Create(char[,] map)
    {
        var (height, width) = (map.GetLength(0), map.GetLength(1));
        var result = new IMapCell[height, width];
        for (int x = 0; x < height; x++)
        {
            for (int y = 0; y < width; y++)
            {
                result[x, y] = Create(map[x, y]);
            }
        }
        
        for (int y = 0; y < width; y++)
            result[height - 1, y] = new EndLineMapCell(result[height - 1, y]);

        return result;
    }
    
    public IMapCell Create(char character)
    {
        switch (character)
        {
            case ' ':
                return new PlaceToMove();
            case '.':
                return new ScorePoint();
            case '#':
                return new Wall();
            default:
                throw new ArgumentOutOfRangeException(nameof(character));
        }
    }
}