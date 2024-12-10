using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        // Utwórz BigBounceMap o wymiarach 8x6
        BigBounceMap map = new(8, 6);

        // Lista obiektów na mapie
        List<IMappable> creatures = new List<IMappable>
        {
            new Elf("Elf Warrior", 3),
            new Orc("Orc Berserker", 5),
            new Animals("Rabbits", 5),
            new Birds("Eagles", 4, true),
            new Birds("Ostriches", 4, false)
        };

        // Pozycje początkowe (zlokalizowane blisko lub na krawędziach mapy)
        List<Point> points = new List<Point>
        {
            new(0, 0), // Elf
            new(7, 0), // Orc
            new(3, 3), // Rabbits
            new(1, 5), // Eagles
            new(4, 5)  // Ostriches
        };

        // Ruchy (zapewniają testowanie odbijania i ruchów skośnych)
        string moves = "uuurrrddlldduuullllrrrd"; // 20 ruchów

        // Inicjalizacja symulacji
        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);

        // Pętla symulacji
        while (!simulation.Finished)
        {
            Console.Clear();
            Console.WriteLine($"Turn {simulation.CurrentMappable}: {simulation.CurrentMoveName}");
            mapVisualizer.Draw();
            simulation.Turn();
            Thread.Sleep(1500);
        }

        // Końcowe wyświetlenie
        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}