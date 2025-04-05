
using System.ComponentModel;

namespace Simulator.Maps;

public class BigMap : Map
{
    protected BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 1000) throw new ArgumentOutOfRangeException(nameof(sizeX), "Szerokość mapy musi wynosić maksymalnie 1000.");
        if (sizeY > 1000) throw new ArgumentOutOfRangeException(nameof(sizeY), "Długość mapy musi wynosić maksymalnie 1000.");
    }
}
