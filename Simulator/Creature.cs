using Simulator.Maps;
namespace Simulator;

public abstract class Creature : IMappable
{
    public Map? Maps {  get; private set; }
    public Point? Position { get; private set; }

    public virtual char Symbol => 'C';

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

    public void InitMapAndPosition(Map map, Point position)
    {
        if (!map.Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map bounds");

        Maps = map;
        Position = position;

        map.Add(this, position);
    }
    public void Go(Direction direction)
    {
        if (Maps == null || Position == null)
            return;

        var newPosition = Maps.Next(Position.Value, direction);
        if (!newPosition.Equals(Position.Value))
        {
            Maps.Move(this, Position.Value, newPosition);
            Position = newPosition;
        }
    }
    public List<string> Go(List<Direction> directions)
    {
        var result = new List<string>(directions.Count);
        foreach (var direction in directions)
        {
            Go(direction);
            result.Add(direction.ToString().ToLower());
        }
        return result;
    }
    public List<string> Go(string s) => Go(DirectionParser.Parse(s));
}
