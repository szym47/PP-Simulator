using System;

namespace Simulator;

public class Elf : Creature
{
    private int agility = 1;
    
    public int Agility { get => agility; init => agility = Validator.Limiter(value, 0, 10); }

    private int count = 0;
    public void Sing()
    {
        count++;
        if (count % 3 == 0)
        {
            if (agility < 10)
            {
                agility++;
            }
        }
    }

    public override int Power => 8 * Level + 2 * Agility;

    public Elf() { }
    public Elf(string name = "Unknown Elf", int level = 1, int agility = 1) : base(name, level)
    {
        Agility = agility;
    }
    public override string Greeting()
    {
        return($"Hi, I'm {Name}, my level is {Level}, my agility is {Agility}");
    }
    public override string Info => $" {Name} [{Level}][{Agility}]";
}