namespace Simulator.Maps;

/// <summary>
/// Map of points.
/// </summary>
public abstract class Map
{

    private readonly Rectangle bounds;
    public int SizeX { get; }
    public int SizeY { get; }
    protected abstract List<Creature>?[,] Fields { get; }
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
    public abstract Point Next(Point p, Direction d);

    /// <summary>
    /// Next diagonal position to the point in a given direction 
    /// rotated 45 degrees clockwise.
    /// </summary>
    /// <param name="p">Starting point.</param>
    /// <param name="d">Direction.</param>
    /// <returns>Next point.</returns>
    public abstract Point NextDiagonal(Point p, Direction d);

    public void Add(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        Fields[position.X, position.Y] ??= new List<Creature>();
        Fields[position.X, position.Y]!.Add(creature);
    }

    public void Remove(Creature creature, Point position)
    {
        if (!Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map");

        Fields[position.X, position.Y] ??= new List<Creature>(); 
        Fields[position.X, position.Y]!.Remove(creature);
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

        Fields[position.X, position.Y] ??= new List<Creature>();
        return Fields[position.X, position.Y]!;
    }

    public List<Creature> At(int x, int y) => At(new Point(x, y));

}