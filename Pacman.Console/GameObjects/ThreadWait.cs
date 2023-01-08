namespace Pacman.Console.GameObjects;

public class ThreadWait : IGameObject
{
    private readonly TimeSpan _waitTime;

    public ThreadWait()
        : this(TimeSpan.FromSeconds(1))
    {
    }
    
    public ThreadWait(TimeSpan waitTime)
    {
        _waitTime = waitTime;
    }

    public void Update()
    {
        Thread.Sleep(_waitTime);
    }
}