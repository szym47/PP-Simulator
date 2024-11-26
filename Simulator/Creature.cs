using Simulator.Maps;
namespace Simulator;

public abstract class Creature
{
    public Map? Maps {  get; private set; }
    public Point Position { get; private set; }

    public void IinitMapAndPosition(Map map, Point position) { }


    private string name = "Unknown";
    public string Name
    {
        get => name;
        init => name = Validator.Shortener(value, 3, 25, '#');
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
        Level = level;
    }

    public abstract string Info {  get; }
    public override string ToString() => $"{GetType().Name.ToUpper()} :{Info}";
   


    public abstract string Greeting();

    public int Upgrade() => level < 10 ? ++level : level;

    public string Go(Direction direction) => $"{direction.ToString().ToLower()}";
    public List<string> Go(List<Direction> directions)
    {
        //Map.Next()
        //Map.Next() == Position -> bez ruchu

        // Map.Move() -> Remove w punkcie 1, Add w punkcie 2
        var size = directions.Count;
        var list = new List<string>(size);
        for (int i = 0; i < size; i++) list[i]=Go(directions[i]);
        return list;
    }

    public List<string> Go(string s) => Go(DirectionParser.Parse(s));
}
