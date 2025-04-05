namespace Simulator.Maps;

public class BigTorusMap : BigMap
{
    public BigTorusMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        FNext = MoveLogic.TorusNext;
        FNextDiagonal = MoveLogic.TorusNextDiagonal;
    }
}
