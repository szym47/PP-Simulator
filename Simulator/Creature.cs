﻿namespace Simulator;

internal class Creature
{
    public string? Name { get; set; }
    public int Level { get; set; }

    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level;
    }

    public Creature() { }


    public string Info => $"{Name} [{Level}]";

    public void SayHi() =>
        Console.WriteLine($"Hi, I am {Name} and my level is {Level}.");
 
}
