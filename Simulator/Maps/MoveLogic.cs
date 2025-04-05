namespace Simulator.Maps;

public static class MoveLogic
{
    public static Point WallNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }

    public static Point WallNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return m.Exist(nextPoint) ? nextPoint : p;
    }
    public static Point TorusNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return d switch
        {
            Direction.Up => m.Exist(nextPoint) ? nextPoint : new Point(p.X, 0),
            Direction.Right => m.Exist(nextPoint) ? nextPoint : new Point(0, p.Y),
            Direction.Down => m.Exist(nextPoint) ? nextPoint : new Point(p.X, m.SizeY - 1),
            Direction.Left => m.Exist(nextPoint) ? nextPoint : new Point(m.SizeX - 1, p.Y),
            _ => default,
        };
    }

    public static Point TorusNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return d switch
        {
            Direction.Up => m.Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % m.SizeX, (p.Y + 1) % m.SizeY),
            Direction.Right => m.Exist(nextPoint) ? nextPoint : new Point((p.X + 1) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY),
            Direction.Down => m.Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y - 1 + m.SizeY) % m.SizeY),
            Direction.Left => m.Exist(nextPoint) ? nextPoint : new Point((p.X - 1 + m.SizeX) % m.SizeX, (p.Y + 1) % m.SizeY),
            _ => default,
        };
    }
    public static Point BounceNext(Map m, Point p, Direction d)
    {
        Point nextPoint = p.Next(d);
        return d switch
        {
            Direction.Up => m.Exist(nextPoint) ? nextPoint : p.Next(Direction.Down),
            Direction.Right => m.Exist(nextPoint) ? nextPoint : p.Next(Direction.Left),
            Direction.Down => m.Exist(nextPoint) ? nextPoint : p.Next(Direction.Up),
            Direction.Left => m.Exist(nextPoint) ? nextPoint : p.Next(Direction.Right),
            _ => default,
        };
    }
    public static Point BounceNextDiagonal(Map m, Point p, Direction d)
    {
        Point nextPoint = p.NextDiagonal(d);
        return d switch
        {
            Direction.Up => m.Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Down),
            Direction.Right => m.Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Left),
            Direction.Down => m.Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Up),
            Direction.Left => m.Exist(nextPoint) ? nextPoint : p.NextDiagonal(Direction.Right),
            _ => default,
        };
    }
}
