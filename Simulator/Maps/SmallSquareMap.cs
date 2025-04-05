namespace Simulator.Maps;

public class SmallSquareMap : SmallMap
{
    public SmallSquareMap(int size) : base(size, size)
    {
        FNext = MoveLogic.WallNext;
        FNextDiagonal = MoveLogic.WallNextDiagonal;
    }
}
