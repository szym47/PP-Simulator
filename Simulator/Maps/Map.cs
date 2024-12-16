namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    private readonly Rectangle bounds;
    public int SizeX { get; }
    public int SizeY { get; }

    private readonly Dictionary<Point, List<IMappable>> mapElements;
    protected override List<IMappable>?[,] Fields { get; }
    protected Map(int sizeX, int sizeY)
    {
        if (sizeX < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width too small");
        }
        if (sizeY < 5)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height too small");
        }
        SizeX = sizeX;
        SizeY = sizeY;
        bounds = new Rectangle(0, 0, SizeX - 1, SizeY - 1);
        mapElements = new Dictionary<Point, List<IMappable>>();

        // Initialize the Fields array
        Fields = new List<IMappable>?[sizeX, sizeY];
        for (int x = 0; x < sizeX; x++)
        {
            for (int y = 0; y < sizeY; y++)
            {
                Fields[x, y] = null;
            }
        }
    }

    /// <summary>
    /// Check if give point belongs to the map.
    /// </summary>
    /// <param name="p">Point to check.</param>
    /// <returns></returns>
    public virtual bool Exist(Point p) => bounds.Contains(p);

    /// <summary>
    /// Next position to the point in a given direction.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point Next(Point p, Direction d, object entity = null);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);


    public void Add(IMappable mappable, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Position is outside the bounds of the map.");

        if (!mapElements.ContainsKey(position))
        {
            mapElements[position] = new List<IMappable>();
        }
        mapElements[position].Add(mappable);

        // Update the Fields array
        Fields[position.X, position.Y] = mapElements[position];
    }

    public void Remove(IMappable mappable, Point position)
    {
        if (mapElements.ContainsKey(position))
        {
            mapElements[position].Remove(mappable);

            if (mapElements[position].Count == 0)
            {
                mapElements.Remove(position);
                Fields[position.X, position.Y] = null;
            }
            else
            {
                Fields[position.X, position.Y] = mapElements[position];
            }
        }
    }

    public List<IMappable> At(Point position)
    {
        return mapElements.ContainsKey(position) ? new List<IMappable>(mapElements[position]) : new List<IMappable>();
    }

    public void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }
    public Map Copy()
    {
        // Tworzymy nową instancję mapy korzystając z konstruktora klasy
        var copy = (Map)Activator.CreateInstance(GetType(), SizeX, SizeY)!;

        for (int x = 0; x < SizeX; x++)
        {
            for (int y = 0; y < SizeY; y++)
            {
                if (Fields[x, y] != null)
                {
                    // Kopiujemy wszystkie elementy z danego pola
                    foreach (var mappable in Fields[x, y]!)
                    {
                        copy.Add(mappable, new Point(x, y));
                    }
                }
            }
        }
        return copy;
    }
}