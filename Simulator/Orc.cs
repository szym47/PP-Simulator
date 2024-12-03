﻿using System.Security.Cryptography.X509Certificates;

namespace Simulator;

public class Orc : Creature
{
    public override char Symbol => 'O';
    private int rage = 1;
    public int Rage { get => rage; init => rage = Validator.Limiter(value, 0, 10); }
    
    private int count = 0;
    public void Hunt()
    {
        count++;
        if (count % 2 == 0)
        {
            if (rage < 10)
            {
                rage++;
            }
        }
    }

    public override int Power => 7 * Level + 3 * Rage;

    public Orc() { }
    public Orc(string name = "Unknown Orc", int level = 1, int rage = 1) : base(name, level)
    {
        Rage = rage;
    }

    public override string Info => $" {Name} [{Level}][{Rage}]";
    public override string Greeting() {
        return($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}");
    }
}