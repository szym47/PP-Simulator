using Simulator;
using Simulator.Maps;
using System.Collections.Generic;
using System.Linq;

namespace Simulator.Maps;

public abstract class BigMap : Map
{
    public BigMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width too big");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height too big");
        }
    }
}
