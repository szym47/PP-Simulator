namespace Simulator;

public abstract class Creature
{

    private string name = "Unknown";
    public string Name
    {
        get => name;
        init {
            name = Validator.Shortener(value, 3, 25, '#');
        }
    }

    private int level = 1;
    public int Level
    {
        get => level;
        init => level = Validator.Limiter(value, 1, 10);
        
    }

    public abstract int Power { get; }


    public Creature() { }
    public Creature(string name, int level = 1)
    {
        Name = name;
        Level = level >= 1 ? level : 1;
    }

    public abstract string Info {  get; }
    public override string ToString() => $"{GetType().Name.ToUpper()} :{Info}";
   


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
