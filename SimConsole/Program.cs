using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        BigBounceMap map = new(8, 6);

        List<IMappable> creatures = new List<IMappable>
        {
            new Elf("Elf Warrior", 3),
            new Orc("Orc Berserker", 5),
            new Animals("Rabbits", 5),
            new Birds("Eagles", 4, true),
            new Birds("Ostriches", 4, false)
        };

        List<Point> points = new List<Point>
        {
            new(0, 0),
            new(7, 0),
            new(3, 3),
            new(1, 5),
            new(4, 5)
        };

        string moves = "uuurrrddlldduuullllr";

        Simulation simulation = new(map, creatures, points, moves);
        SimulationHistory history = new(simulation);
        MapVisualizer mapVisualizer = new(simulation.Map);

        while (!simulation.Finished)
        {
            Console.Clear();
            Console.WriteLine($"Turn {simulation.TurnNumber}: {simulation.CurrentMappable} moves {simulation.CurrentMoveName}");
            mapVisualizer.Draw();
            simulation.Turn();
            Thread.Sleep(1500);
        }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");

        Console.WriteLine("\nSimulation History Review:");
        foreach (var turn in new[] { 5, 10, 15, 20 })
        {
            var snapshot = history.GetSnapshot(turn);
            Console.WriteLine($"\nTurn {snapshot.TurnNumber}:");
            MapVisualizer visualizer = new(snapshot.MapState);
            visualizer.Draw();
            Console.WriteLine($"Current Move: {snapshot.CurrentMove}");
            Console.WriteLine($"Current Mappable: {snapshot.CurrentMappable}");
            Console.WriteLine();
        }

        Console.WriteLine("Simulation history review finished!");
    }
}