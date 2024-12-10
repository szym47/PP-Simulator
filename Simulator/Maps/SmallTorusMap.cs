namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    private Point ToTorus(Point point)
    {
        return new Point((point.X + SizeX) % SizeX, (point.Y + SizeY) % SizeY);
    }

    public override Point Next(Point p, Direction d, object entity = null) =>ToTorus(p.Next(d));

    public override Point NextDiagonal(Point p, Direction d) => ToTorus(p.NextDiagonal(d));
    public override Map Copy()
    {
        var copy = (SmallTorusMap)base.Copy();
        return copy;
    }

}

