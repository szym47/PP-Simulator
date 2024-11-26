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
    public List<Creature> Creatures { get; }

    /// <summary>
    /// Starting positions of creatures.
    /// </summary>
    public List<Point> Positions { get; }

    /// <summary>
    /// Cyclic list of creatures moves. 
    /// Bad moves are ignored - use DirectionParser.
    /// First move is for first creature, second for second and so on.
    /// When all creatures make moves, 
    /// next move is again for first creature and so on.
    /// </summary>
    public string Moves { get; }

    /// <summary>
    /// Has all moves been done?
    /// </summary>
    public bool Finished => currentMoveIndex >= Moves.Length;

    /// <summary>
    /// Creature which will be moving current turn.
    /// </summary>
    public Creature CurrentCreature => Creatures[currentMoveIndex % Creatures.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    public string CurrentMoveName => Moves[currentMoveIndex % Moves.Length].ToString().ToLower();

    private int currentMoveIndex = 0;

    /// <summary>
    /// Simulation constructor.
    /// Throw errors:
    /// if creatures' list is empty,
    /// if number of creatures differs from 
    /// number of starting positions.
    /// </summary>
    public Simulation(Map map, List<Creature> creatures,
        List<Point> positions, string moves)
    {
        if (creatures.Count == 0)
            throw new ArgumentException("The creatures list cannot be empty.", nameof(creatures));
        if (creatures.Count != positions.Count)
            throw new ArgumentException("The number of creatures must match the number of starting positions.", nameof(positions));
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves cannot be null or empty.", nameof(moves));

        Map = map;
        Creatures = creatures;
        Positions = positions;
        Moves = moves;

        // Assign creatures to the map at their starting positions
        for (int i = 0; i < creatures.Count; i++)
        {
            var creature = creatures[i];
            var position = positions[i];

            if (!map.Exist(position))
                throw new ArgumentException($"Position {position} is outside the bounds of the map.");

            creature.InitMapAndPosition(map, position);
        }
    }


    /// <summary>
    /// Makes one move of current creature in current direction.
    /// Throw error if simulation is finished.
    /// </summary>
    public void Turn() {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished. ");

        var currentDirection = DirectionParser.Parse(CurrentMoveName);

        // Move the current creature if the direction is valid
        if (currentDirection != null)
        {
            CurrentCreature.Go(currentDirection);
        }

        // Move to the next turn
        currentMoveIndex++;
    }
}