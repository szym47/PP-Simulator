using Simulator.Maps;

namespace Simulator;

public class Birds : Animals
{
    public bool CanFly { get; init; } = true;
    public override char Symbol => CanFly ? 'B' : 'b';

    public Birds(string description = "Unknown Bird", int size=3, bool canFly=true) : base(description, size) 
    {
        CanFly = canFly;
    }

    public override string Info
    {
        get
        {
            string flying_skill = CanFly ? "fly+" : "fly-";
            return $"{Description} ({flying_skill}) <{Size}>";
        }
    }
    public override void Go(Direction direction)
    {
        if (Maps == null) throw new InvalidOperationException("Map is not initialized.");
        var nextPosition = CanFly?  Maps.Next(Maps.Next(Position,direction), direction) : Maps.NextDiagonal(Position, direction);
        if (Maps.Exist(nextPosition))
        {
            Maps.Move(this, Position, nextPosition);
            Position = nextPosition;
        }
    }
}
