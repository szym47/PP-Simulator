using Simulator.Maps;

namespace Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Creatures { get; }

    /// <summary>
    /// Starting positions of mappables.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of mappables moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first mappable, second for second and so on.
    /// When all mappables make moves, 
    /// next move is again for first mappable and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => currentMoveIndex >= Moves.Length;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => Creatures[currentMoveIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[currentMoveIndex % Moves.Length].ToString().ToLower();

    private int currentMoveIndex = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if mappables' list is empty,
    /// if number of mappables differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
            throw new ArgumentException("The mappables list cannot be empty.", nameof(mappables));
        if (mappables.Count != positions.Count)
            throw new ArgumentException("The number of mappables must match the number of starting positions.", nameof(positions));
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves cannot be null or empty.", nameof(moves));

        Map = map;
        Creatures = mappables;
        Positions = positions;
        Moves = moves;

        // Assign mappables to the map at their starting positions
        for (int i = 0; i < mappables.Count; i++)
        {
            var mappable = mappables[i];
            var position = positions[i];

            if (!map.Exist(position))
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");

            mappable.InitMapAndPosition(map, position);
        }
    }


    /// <summary>
    /// Makes one move of current mappable in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished. ");

        var currentDirections = DirectionParser.Parse(CurrentMoveName);

        if (currentDirections != null && currentDirections.Any())
        {
            foreach (var direction in currentDirections)
            {
                CurrentMappable.Go(direction);
            }
        }

        // Move to the next turn
        currentMoveIndex++;
    }
}