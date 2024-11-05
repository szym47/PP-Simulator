namespace Simulator;

public class Orc : Creature
{
    private int rage = 1;
    
    public int Rage { get => rage; init => rage = value < 0 ? 0 : value > 10 ? 10 : value; }
    
    private int count = 0;
    public void Hunt()
    {
        count++;
        Console.WriteLine($"{Name} is hunting.");
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
    public override void SayHi() {
        Console.WriteLine($"Hi, I'm {Name}, my level is {Level}, my rage is {Rage}");
    }
}