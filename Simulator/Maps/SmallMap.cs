namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>[,] _fields;

    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width too big");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height too big");
        }

        _fields = new List<Creature>[sizeX, sizeY];
        for (int i = 0; i < sizeX; i++)
            for (int j = 0; j < sizeY; j++)
                _fields[i, j] = new List<Creature>();
    }
    public void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        _fields[position.X, position.Y].Add(creature);
    }

    public void Remove(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        _fields[position.X, position.Y].Remove(creature);
    }

    public void Move(Creature creature, Point from, Point to)
    {
        if (!Exist(from) || !Exist(to))
            throw new ArgumentOutOfRangeException("Source or destination point is outside the map");

        Remove(creature, from);
        Add(creature, to);
    }

    public List<Creature> At(Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        return _fields[position.X, position.Y];
    }

    public List<Creature> At(int x, int y) => At(new Point(x, y));
}
