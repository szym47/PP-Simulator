﻿using System.Text;
using Simulator;
using Simulator.Maps;

namespace SimConsole;

internal class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;

        SmallSquareMap map = new(5);
        List<IMappable> creatures = [new Orc("Gorbag"), new Elf("Elandor")];
        List<Point> points = [new(2, 2), new(3, 1)];
        string moves = "dlrludl";

        Simulation simulation = new(map, creatures, points, moves);
        MapVisualizer mapVisualizer = new(simulation.Map);
        while (!simulation.Finished)
        {
            Console.Clear();
            mapVisualizer.Draw();
            Console.WriteLine($"Current move: {simulation.CurrentMoveName}");
            simulation.Turn();
            Thread.Sleep(1000);
        }

        Console.Clear();
        mapVisualizer.Draw();
        Console.WriteLine("Simulation finished!");
    }
}
