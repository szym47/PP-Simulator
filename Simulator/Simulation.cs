using Simulator.Maps;
using Simulator;

public class Simulation
{
    /// <summary>
    /// Simulation's map.
    /// </summary>
    public Map Map { get; }

    /// <summary>
    /// Creatures moving on the map.
    /// </summary>
    public List<IMappable> Mappables { get; }

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
    public bool Finished { get; private set; } = false;

    /// <summary>
    /// IMappable which will be moving current turn.
    /// </summary>
    public IMappable CurrentMappable => Mappables[currentMoveIndex % Mappables.Count];

    /// <summary>
    /// Lowercase name of direction which will be used in current turn.
    /// </summary>
    private int currentMoveIndex = 0;
    private List<Direction> ParsedMoves { get; }
    public string CurrentMoveName => ParsedMoves.Count > currentMoveIndex ? ParsedMoves[currentMoveIndex].ToString().ToLower() : string.Empty;

    /// <summary>
    /// The current turn number, starting from 1.
    /// </summary>
    public int TurnNumber => currentMoveIndex + 1;

    public Simulation(Map map, List<IMappable> mappables, List<Point> positions, string moves)
    {
        if (mappables.Count == 0)
            throw new ArgumentException("The mappables list cannot be empty.", nameof(mappables));
        if (mappables.Count != positions.Count)
            throw new ArgumentException("The number of mappables must match the number of starting positions.", nameof(positions));
        if (string.IsNullOrWhiteSpace(moves))
            throw new ArgumentException("Moves cannot be null or empty.", nameof(moves));

        Map = map;
        Mappables = mappables;
        Positions = positions;
        Moves = moves;

        ParsedMoves = Moves
           .Select(c => DirectionParser.Parse(c.ToString().ToLower()))
           .Where(d => d != null && d.Count > 0)
           .Select(d => d[0])
           .ToList();

        if (ParsedMoves.Count == 0)
        {
            throw new ArgumentException("Moves must contain at least one valid direction.");
        }
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
    public void Turn()
    {
        if (Finished)
            throw new InvalidOperationException("Simulation is finished. ");

        Direction direction = ParsedMoves[currentMoveIndex];
        CurrentMappable.Go(direction);

        currentMoveIndex++;

        if (currentMoveIndex >= ParsedMoves.Count)
        {
            Finished = true;
            return;
        }
    }
}
