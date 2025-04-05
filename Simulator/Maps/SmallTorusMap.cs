namespace Simulator.Maps;

public class SmallTorusMap : SmallMap
{
    public SmallTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveLogic.TorusNext;
        FNextDiagonal = MoveLogic.TorusNextDiagonal;
    }
}
