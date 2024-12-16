namespace Simulator.Maps;

public interface IMappable
{
    void Go(Direction direction);
    void InitMapAndPosition(Map map, Point position);
    public char Symbol { get; } // umowny symbol obiektu
    public string ToString();
    // sugerujemy override, bo object.ToString() zwraca string?
}
