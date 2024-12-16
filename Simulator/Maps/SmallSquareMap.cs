namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size,object entity=null) : base(size, size) { }


    public override Point Next(Point p, Direction d, object entity = null)
    {
        Point next;
        if (Exist(p))
        {
            switch (d)
            {
                case (Direction.Up):
                    next = new Point(p.X, p.Y + 1); break;
                case (Direction.Down):
                    next = new Point(p.X, p.Y - 1); break;
                case (Direction.Left):
                    next = new Point(p.X - 1, p.Y); break;
                case (Direction.Right):
                    next = new Point(p.X + 1, p.Y); break;
                default:
                    return p;


            }
            if (Exist(next))
            {
                return next;
            }

        }
        return p;

    }




    public override Point NextDiagonal(Point p, Direction d)
    {
        Point nextDiagonal;
        if (Exist(p))
        {
            switch (d)
            {
                case (Direction.Up):
                    nextDiagonal = new Point(p.X + 1, p.Y + 1); break;
                case (Direction.Down):
                    nextDiagonal = new Point(p.X - 1, p.Y - 1); break;
                case (Direction.Right):
                    nextDiagonal = new Point(p.X + 1, p.Y - 1); break;
                case (Direction.Left):
                    nextDiagonal = new Point(p.X, p.Y + 1); break;
                default:
                    return p;
            }
            if (Exist(nextDiagonal))
            {
                return nextDiagonal;
            }

        }
        return p;
    }
}