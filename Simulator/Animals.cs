using Simulator.Maps;
using System.Drawing;

namespace Simulator;

public class Animals : IMappable
{
    private string description = "Unknown";
    public Map? Maps { get; private set; }
    public Point Position { get; set; }

    public string Description
    {
        get => description;
        init=> description = Validator.Shortener(value, 3, 15, '#');
    }

    public int Size { get; set; } = 3;
    public virtual string Info => $"{Description} <{Size}>";
    public override string ToString()=> $"{GetType().Name.ToUpper()}: {Info}";
    
    public virtual char Symbol => 'A';
    public void InitMapAndPosition(Map map, Point position)
    {
        if (!map.Exist(position))
            throw new ArgumentOutOfRangeException(nameof(position), "Point is outside the map bounds");

        Maps = map;
        Position = position;

        ((SmallMap)map).Add(this, position);
    }

    public virtual void Go(Direction direction)
    {
        if (Maps == null) throw new InvalidOperationException("Map is not initialized.");
        var nextPosition = Maps.Next(Position, direction);
        if (Maps.Exist(nextPosition))
        {
            Maps.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }

    public Animals(string Description, int size)
    {
        Description = description;
        Size = size;
    }
}