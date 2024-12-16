using Simulator;

namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY) { }

    public override Point Next(Point position, Direction direction, object entity = null)
    {
        // Sprawdzenie, czy obiekt jest latającym ptakiem
        bool isFlyingBird = entity is Birds bird && bird.CanFly;
        if (isFlyingBird)
        {
            var firstStep = position.Next(direction);
            if (!Exist(firstStep))
            {
                // Odwrócenie kierunku przy pierwszym kroku
                direction = direction switch
                {
                    Direction.Up => Direction.Down,
                    Direction.Down => Direction.Up,
                    Direction.Left => Direction.Right,
                    Direction.Right => Direction.Left,
                    _ => direction
                };
                firstStep = position.Next(direction);
            }
            var secondStep = firstStep.Next(direction);
            if (!Exist(secondStep))
            {
                // Jeśli drugi krok wychodzi poza mapę, ptak wraca na pierwotną pozycję
                return position;
            }
            return secondStep;
        }
        else
        {
            var nextPoint = position.Next(direction);
            if (!Exist(nextPoint))
            {
                // Odwrócenie kierunku
                direction = direction switch
                {
                    Direction.Up => Direction.Down,
                    Direction.Down => Direction.Up,
                    Direction.Left => Direction.Right,
                    Direction.Right => Direction.Left,
                    _ => direction
                };
                nextPoint = position.Next(direction);
            }
            return nextPoint;
        }
    }

    public override Point NextDiagonal(Point position, Direction direction)
    {
        var newPosition = position.NextDiagonal(direction);

    //  sytuacje bez ruchu
        bool inLeftBottomCorner = position.Y == 0 && (position.X == 0) && (direction == Direction.Left || direction == Direction.Right);
        bool inRightBottomCorner = position.Y == 0 && (position.X == SizeX - 1) && (direction == Direction.Up || direction == Direction.Down);
        bool inLeftTopCorner = position.Y == SizeY - 1 && (position.X == 0) && (direction == Direction.Up || direction == Direction.Down);
        bool inRightTopCorner = position.Y == SizeY - 1 && (position.X == SizeX - 1) && (direction == Direction.Right || direction == Direction.Left);

        if (!Exist(newPosition))
        {
            if (inLeftBottomCorner || inRightBottomCorner || inLeftTopCorner || inRightTopCorner)
            {
                return position;
            }
            //odwrocenie kierunku
            direction = direction switch
            {
                Direction.Up => Direction.Down,
                Direction.Down => Direction.Up,
                Direction.Left => Direction.Right,
                Direction.Right => Direction.Left,
                _ => direction
            };
            newPosition = position.NextDiagonal(direction);
        }

        return newPosition;
    }
}
