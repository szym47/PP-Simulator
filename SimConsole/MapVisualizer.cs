using System.Text;
using SimConsole;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

public class MapVisualizer
{
    private readonly Map map;

    public MapVisualizer(Map map)
    {
        this.map = map;
    }

    public void Draw()
    {
        int width = map.SizeX;
        int height = map.SizeY;

        Console.Write(Box.TopLeft);
        for (int x = 0; x < width; x++) 
        { 
            Console.Write(Box.Horizontal);
            if (x < width - 1) 
                Console.Write(Box.TopMid);
        }
        Console.WriteLine(Box.TopRight);

        for (int y = 0; y < height; y++)
        {
            Console.Write(Box.Vertical); 

            for (int x = 0; x < width; x++)
            {
                var creatures = map.At(new Point(x,y));
                if (creatures.Count > 1)
                    Console.Write('X');
                else if (creatures.Count == 1)
                {
                    var creature = creatures[0];
                    Console.Write(creature.Symbol);
                }
                else
                {
                    Console.Write(' '); 
                }
                if (x < width - 1)
                {
                    Console.Write(Box.Vertical);
                }
            }
            Console.WriteLine(Box.Vertical);

            if (y < height-1)
            {
                Console.Write(Box.MidLeft);
                for (int x = 0; x < width; x++)
                {
                    Console.Write(Box.Horizontal);
                    if (x < width - 1) 
                        Console.Write(Box.Cross);
                }
                Console.WriteLine(Box.MidRight);
            }
        }
    

        Console.Write(Box.BottomLeft);
        for (int x = 0; x < width; x++)
        {
            Console.Write(Box.Horizontal);
            if (x < width - 1) 
                Console.Write(Box.BottomMid);
        }
        Console.WriteLine(Box.BottomRight);
    }
}