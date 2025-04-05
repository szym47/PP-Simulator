using Simulator.Maps;
using System.Text.Json;
using System.Text.Json.Serialization;
namespace Simulator;
internal class Program
{
    static void Main(string[] args)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };

        List<IMappable> mapables = [
            new Orc("Gorbag", 3, 5),
        new Elf("Elandor", 2, 7),
        new Animals { Description = "Rasbbits", Size = 10 },
        new Birds { Description = "Eagles", Size = 15 },
        new Birds { Description = "Emu", Size = 8, CanFly = false }
        ];

        string json = JsonSerializer.Serialize(mapables, options);
        Console.WriteLine("\nJSON:");
        Console.WriteLine(json);

        List<IMappable> deserialized =
            JsonSerializer.Deserialize<List<IMappable>>(json, options)!;
    }

}
