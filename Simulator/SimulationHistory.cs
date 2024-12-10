using System;
using System.Collections.Generic;
using Simulator.Maps;

namespace Simulator
{
    public class SimulationHistory
    {
        private readonly List<SimulationSnapshot> _snapshots = new();

        public SimulationHistory(Simulation simulation)
        {
            while (!simulation.Finished)
            {
                // Create a snapshot of the current simulation state
                var snapshot = new SimulationSnapshot(
                    mapState: simulation.Map.Copy(),
                    currentMappable: simulation.CurrentMappable,
                    currentMove: simulation.CurrentMoveName,
                    turnNumber: simulation.TurnNumber
                );

                _snapshots.Add(snapshot);
                simulation.Turn(); // Advance the simulation to the next turn
            }
        }

        public SimulationSnapshot GetSnapshot(int turnNumber)
        {
            if (turnNumber < 1 || turnNumber > _snapshots.Count)
                throw new ArgumentOutOfRangeException(nameof(turnNumber), "Invalid turn number.");

            return _snapshots[turnNumber - 1];
        }

        public IEnumerable<SimulationSnapshot> Snapshots => _snapshots;
    }

    public class SimulationSnapshot
    {
        public Map MapState { get; }
        public IMappable CurrentMappable { get; }
        public string CurrentMove { get; }
        public int TurnNumber { get; }

        public SimulationSnapshot(Map mapState, IMappable currentMappable, string currentMove, int turnNumber)
        {
            MapState = mapState;
            CurrentMappable = currentMappable;
            CurrentMove = currentMove;
            TurnNumber = turnNumber;
        }
    }
}
