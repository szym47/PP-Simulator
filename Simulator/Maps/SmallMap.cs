namespace Simulator.Maps;

public abstract class SmallMap : Map
{
    private readonly List<Creature>?[,] fields;
    protected SmallMap(int sizeX, int sizeY) : base(sizeX, sizeY)
    {
        if (sizeX > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeX), "Width too big");
        }
        if (sizeY > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(sizeY), "Height too big");
        }
        fields= new List<Creature>[sizeX, sizeY];  
    }
    protected override List<Creature>?[,] Fields => fields;
}
