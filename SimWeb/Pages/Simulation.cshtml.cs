﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Simulator;
using System.Linq;
using System.Collections.Generic;
using Simulator.Maps;

namespace SimWeb.Pages
{
    public class SimulationModel : PageModel
    {
        private static Simulation _simulation;
        private static SimulationHistory _history;
        private static int _currentTurn = 0;

        public Dictionary<Point, List<char>>? Symbols { get; private set; }
        public int SizeX { get; private set; }
        public int SizeY { get; private set; }
        public int CurrentTurn => _currentTurn;

        public List<List<CreatureAtPoint>> MapGrid { get; set; } = new();

        public void OnGet()
        {
            if (_simulation == null)
            {
                BigBounceMap map = new(8, 6);
                List<IMappable> creatures = new List<IMappable>
                {
                    new Orc("Gorbag"),
                    new Elf("Elandor"),
                    new Animals("Rabbits", 23),
                    new Birds("Eagles", 3),
                    new Birds("Ostriches", 15, false)
                };
                List<Point> points = new List<Point>
                {
                    new(0, 0), new(0, 1), new(0, 2), new(0, 3), new(0, 4)
                };
                string moves = "rrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr";

                _simulation = new Simulation(map, creatures, points, moves);
                _history = new SimulationHistory(_simulation);
                SizeX = map.SizeX;
                SizeY = map.SizeY;
            }

            UpdateSymbols();
            GenerateMapGrid();
        }

        public IActionResult OnPostNext()
        {
            if (_currentTurn < _history.TurnLogs.Count - 1)
            {
                _currentTurn++;
                UpdateSymbols();
                GenerateMapGrid();
            }

            return Page();
        }

        public IActionResult OnPostPrevious()
        {
            if (_currentTurn > 0)
            {
                _currentTurn--;
                UpdateSymbols();
                GenerateMapGrid();
            }

            return Page();
        }
        private void UpdateSymbols()
        {
            Symbols = _history.TurnLogs[_currentTurn].Symbols;
            SizeX = _history.SizeX;
            SizeY = _history.SizeY;
        }
        private void GenerateMapGrid()
        {
            MapGrid.Clear();

            for (int row = 5; row >= 0; row--)
            {
                var rowGrid = new List<CreatureAtPoint>();

                for (int col = 0; col < 8; col++)
                {
                    var point = new Point(col, row);
                    var creaturesAtPoint = Symbols?.FirstOrDefault(s => s.Key.Equals(point)).Value;

                    rowGrid.Add(new CreatureAtPoint
                    {
                        Point = point,
                        Creatures = creaturesAtPoint
                    });
                }

                MapGrid.Add(rowGrid);
            }
        }
        public string GetImageSource(List<char> creatures)
        {
            if (creatures.Count > 1)
            {
                return "<img src='/img/X.png' alt='X' />";
            }

            if (creatures.Contains('A'))
                return "<img src='/img/Rabbit.png' alt='Rabbit' />";
            if (creatures.Contains('E'))
                return "<img src='/img/Elf.png' alt='Elf' />";
            if (creatures.Contains('O'))
                return "<img src='/img/Orc.png' alt='Orc' />";
            if (creatures.Contains('B'))
                return "<img src='/img/Eagle.png' alt='Eagle' />";
            if (creatures.Contains('b'))
                return "<img src='/img/Ostrich.png' alt='Ostrich' />";

            return "";
        }

        public class CreatureAtPoint
        {
            public Point Point { get; set; }
            public List<char>? Creatures { get; set; }
        }
    }
}