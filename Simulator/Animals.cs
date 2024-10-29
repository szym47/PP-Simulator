using System.Drawing;

namespace Simulator;

public class Animals
{
    private string description = "Unknown";
    public required string Description
    {
        get => description;
        init
        {
            description = value.Trim();
            if (description.Length < 3)
            {
                description = description.PadRight(3, '#');
            }
            if (description.Length > 15)
            {
                description = description.Substring(0, 15);
                description = description.Trim();
                if (description.Length < 3)
                {
                    description = description.PadRight(3, '#');
                }
            }
            description = char.ToUpper(description[0]) + description.Substring(1);
        }
    }
    public uint Size { get; set; } = 3;


    public string Info => $"{Description} <{Size}>";
}