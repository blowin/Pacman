namespace Pacman.Console.GameObjects;

public class ClearConsole : IGameObject
{
    public void Update()
    {
        System.Console.Clear();
    }
}