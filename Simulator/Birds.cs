using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; init; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public Birds(string description = "Unknown Bird", int size = 3, bool canFly = true) : base(description, size)
    {
        CanFly = canFly;
    }

    public override string Info
    {
        get
        {
            string flyingSkill = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flyingSkill}) <{Size}>";
        }
    }

    public override void Go(Direction direction)
    {
        if (Maps == null) throw new InvalidOperationException("Map is not initialized.");

        if (CanFly)
        {
            // Latające ptaki wykonują dwa kroki w jednej metodzie Next
            var nextPosition = Maps.Next(Position, direction, this);
            if (Maps.Exist(nextPosition))
            {
                Maps.Move(this, Position, nextPosition);
                Position = nextPosition;
            }
        }
        else
        {
            // Nieloty używają ruchu diagonalnego
            var nextPosition = Maps.NextDiagonal(Position, direction);
            if (Maps.Exist(nextPosition))
            {
                Maps.Move(this, Position, nextPosition);
                Position = nextPosition;
            }
        }
    }
}
