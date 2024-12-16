namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    private Point ToTorus(Point point)
    {
        return new Point((point.X + SizeX) % SizeX, (point.Y + SizeY) % SizeY);
    }

    public override Point Next(Point p, Direction d, object entity = null) => ToTorus(p.Next(d));

    public override Point NextDiagonal(Point p, Direction d) => ToTorus(p.NextDiagonal(d));
}

