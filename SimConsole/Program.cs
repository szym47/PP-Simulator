using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallTorusMap map = new(8, 6);

        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals("Rabbit", 10), 
            new Birds("Eagle", 5, true), 
            new Birds("Ostrich", 4, false) 
        };

        List<Point> points = new List<Point>
        {
            new(2, 2), 
            new(3, 1), 
            new(1, 4), 
            new(4, 4), 
            new(5, 5) 
        };

        string moves = "dlrldulurlldduu"; 

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine($"Current move: {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(1500);
        }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}
