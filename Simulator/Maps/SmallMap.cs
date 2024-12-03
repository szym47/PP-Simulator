using Simulator.Maps;

namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<IMappable>?[,] fields;
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
        fields = new List<IMappable>[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                fields[x, y] = new List<IMappable>();
            }
        }
    }
    protected override List<IMappable>?[,] Fields => fields;


    public override void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        Fields[position.X, position.Y] ??= new List<IMappable>();
        Fields[position.X, position.Y]!.Add(mappable);
    }

    public override void Remove(IMappable mappable, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        Fields[position.X, position.Y] ??= new List<IMappable>(); 
        Fields[position.X, position.Y]!.Remove(mappable);
}

    public override void Move(IMappable mappable, Point from, Point to)
    {
        if (!Exist(from) || !Exist(to))
            throw new ArgumentOutOfRangeException("Source or destination point is outside the map");

        Remove(mappable, from);
        Add(mappable, to);
    }

    public override List<IMappable> At(Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        Fields[position.X, position.Y] ??= new List<IMappable>();
        return Fields[position.X, position.Y]!;
    }

    public List<IMappable> At(int x, int y) => At(new Point(x, y));
}
