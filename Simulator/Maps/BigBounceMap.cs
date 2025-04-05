namespace Simulator.Maps;

public class BigBounceMap : BigMap
{
    public BigBounceMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveLogic.BounceNext;
        FNextDiagonal = MoveLogic.BounceNextDiagonal;
    }

}
