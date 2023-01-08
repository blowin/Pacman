﻿namespace Pacman.Console;

internal class Program
{
    public static void Main(string[] args)
    {
        System.Console.CursorVisible = false;
        
        var map = new GameMap("map.txt");
        var pacman = new Pacman(new IntVector2(1, 1));
        var score = new Score(new IntVector2(32, 0));
        var input = new UserInput(pacman, map, score);
        
        while (true)
        {
            System.Console.Clear();
            input.Update();    
            map.Draw();
            pacman.Draw();
            score.Draw();
            
            Thread.Sleep(1000);
        }
    }
}