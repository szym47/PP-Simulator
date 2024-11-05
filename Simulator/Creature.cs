namespace Simulator;

public abstract class Creature
{

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init
        {
            name = value.Trim();

            if (name.Length < 3)
            {
                name = name.PadRight(3, '#');
            }

            else if (name.Length > 25)
            {
                name = name.Substring(0, 25);
                name = name.Trim();
                if (name.Length < 3)
                {
                    name = name.PadRight(3, '#');
                }
            }

            name = char.ToUpper(name[0]) + name.Substring(1);
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init
        {
            level = value < 1 ? 1 : value > 10 ? 10 : value;
        }
    }

    public abstract int Power { get; }


    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level >= 1 ? level : 1;
    }

    public string Info => $"{Name} [{Level}]";



    public abstract void SayHi();

    public int Upgrade() => level < 10 ? ++level : level;

    public void Go(Direction direction)
    {
        Console.WriteLine($"{name} goes {direction.ToString().ToLower()}.");
    }
    public void Go(Direction[] directions)
    {
        foreach (Direction direction in directions)
        {
            Go(direction);
        }
    }
    public void Go(string directionsS)
    {
        Direction[] directions = DirectionParser.Parse(directionsS);
        Go(directions);
    }
}
