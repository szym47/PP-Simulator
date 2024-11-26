namespace Simulator;

public static class DirectionParser
{
    public static List<Direction> Parse(string input)
    {
        var directions = new List<Direction>();
        foreach (char d in input.ToUpper())
        {
            if (d == 'U')
            {
                directions.Add(Direction.Up);
            }
            else if (d == 'R')
            {
                directions.Add(Direction.Right);
            }
            else if (d == 'D')
            {
                directions.Add(Direction.Down);
            }
            else if (d == 'L')
            {
                directions.Add(Direction.Left);
            }
        }
        return directions;
    }
}
