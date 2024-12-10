using Simulator;
using Simulator.Maps;
using System.Collections.Generic;
using System.Linq;

namespace Simulator.Maps;

 public abstract class BigMap : Map
{
    private readonly Dictionary<Point, List<IMappable>> mapElements;

    protected override List<IMappable>?[,] Fields { get; }

    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width too big");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height too big");
        }
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

    public override void Add(IMappable mappable, Point position)
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

    public override void Remove(IMappable mappable, Point position)
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

    public override List<IMappable> At(Point position)
    {
        return mapElements.ContainsKey(position) ? new List<IMappable>(mapElements[position]) : new List<IMappable>();
    }

    public override void Move(IMappable mappable, Point from, Point to)
    {
        Remove(mappable, from);
        Add(mappable, to);
    }
    public override Map Copy()
    {
        // Tworzymy nową instancję mapy korzystając z konstruktora klasy
        var copy = (BigMap)Activator.CreateInstance(GetType(), SizeX, SizeY)!;

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
