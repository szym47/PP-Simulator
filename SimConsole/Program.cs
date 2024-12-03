using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Tworzymy mapę torusową o wymiarach 8x6
        SmallTorusMap map = new(8, 6);

        // Dodajemy stwory, ptaki oraz różne zwierzęta
        List<IMappable> creatures = new List<IMappable>
        {
            new Orc("Gorbag"),
            new Elf("Elandor"),
            new Animals("Rabbit", 2), // Królik
            new Birds("Eagle", 2, true), // Orzeł (latający)
            new Birds("Ostrich", 4, false) // Struś (nielot)
        };

        // Określamy pozycje tych stworzeń
        List<Point> points = new List<Point>
        {
            new(2, 2), // Pozycja orka
            new(3, 1), // Pozycja elfa
            new(1, 4), // Pozycja królika
            new(4, 4), // Pozycja orła
            new(5, 5)  // Pozycja strusia
        };

        string moves = "dlrldul"; // Przykładowa lista ruchów

        // Tworzymy symulację
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        // Uruchamiamy symulację
        while (!simulation.Finished)
        {
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine($"Current move: {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(2000);
        }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}
