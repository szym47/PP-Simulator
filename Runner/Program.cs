using System.Drawing;
using Simulator.Maps;
using Simulator;
namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Console.WriteLine("Point\n");
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 26)

        Console.WriteLine();
        Lab5a();
        Console.WriteLine();
        Lab5b();
    }
    public static void Lab5a()
    {
        Console.WriteLine("Rectangle\n");
        {
            Rectangle rect1 = new Rectangle(5, 5, 15, 10);
            Console.WriteLine(rect1);

            try
            {
                Rectangle rect2 = new Rectangle(5, 5, 5, 10);
                Console.WriteLine(rect2);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Point p1 = new Point(10, 20);
            Point p2 = new Point(15, 25);

            Rectangle rect3 = new Rectangle(p1, p2);
            Console.WriteLine(rect3);

            try
            {
                Point p3 = new Point(5, 5);
                Point p4 = new Point(5, 10);
                Rectangle rect4 = new Rectangle(p3, p4);
                Console.WriteLine(rect4);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Point testp1 = new Point(7, 8);
            Point testp2 = new Point(20, 20);
            Console.WriteLine(rect1.Contains(testp1));
            Console.WriteLine(rect1.Contains(testp2));
        }
    }
    public static void Lab5b()
    {
        Console.WriteLine("SmallSquareMap\n");

        {
            SmallSquareMap map1 = new SmallSquareMap(10);

            Console.WriteLine($"Mapa o rozmiarze {map1.Size} utworzona poprawnie.");
            try
            {
                SmallSquareMap map2 = new SmallSquareMap(21);
                Console.WriteLine($"Mapa o rozmiarze {map2.Size} utworzona poprawnie.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Błąd: {ex.Message}");
            }


            Point insidePoint = new Point(5, 5);
            Console.WriteLine($"{insidePoint} - {map1.Exist(insidePoint)}");   // true

            Point cornerPoint = new Point(0, 0);
            Console.WriteLine($"{cornerPoint} - {map1.Exist(cornerPoint)}");  // true

            Point borderPoint = new Point(8, 0);
            Console.WriteLine($"{borderPoint} - {map1.Exist(borderPoint)}");  // true

            Point outsidePoint = new Point(10, 10);
            Console.WriteLine($"{outsidePoint} - {map1.Exist(outsidePoint)}");  // false
            
            var movedPoint= new Point(0,0);
            Console.WriteLine("\nRuch w mapie:");
            Console.WriteLine($"Punkt początkowy: {insidePoint}");
            movedPoint = map1.Next(insidePoint, Direction.Right);
            Console.WriteLine($"{insidePoint}, Right -> {movedPoint}");  // (6, 5)
            movedPoint = map1.Next(insidePoint, Direction.Up);
            Console.WriteLine($"{insidePoint}, Up -> {movedPoint}");    // (5, 6)


            Console.WriteLine("\nRuch poza mapa:");
            Console.WriteLine($"Punkt początkowy: {cornerPoint}");
            movedPoint = map1.Next(cornerPoint, Direction.Down);
            Console.WriteLine($"{cornerPoint}, Down -> {movedPoint}"); // (0 0)
            movedPoint = map1.Next(cornerPoint, Direction.Left);
            Console.WriteLine($"{cornerPoint}, Left -> {movedPoint}"); // (0, 0)
            Console.WriteLine($"Punkt początkowy: {outsidePoint}");
            movedPoint = map1.Next(outsidePoint, Direction.Left);
            Console.WriteLine($"{outsidePoint}, Left -> {movedPoint}"); // (10, 10)


            Console.WriteLine("\nRuch diagonalny:");
            Console.WriteLine($"Punkt początkowy: {insidePoint}");
            movedPoint = map1.NextDiagonal(insidePoint, Direction.Up);
            Console.WriteLine($"{insidePoint}, Up -> {movedPoint}");  // (6, 6)
            Console.WriteLine($"Punkt początkowy: {cornerPoint}");
            movedPoint = map1.NextDiagonal(cornerPoint, Direction.Right);
            Console.WriteLine($"{cornerPoint}, Right -> {movedPoint}");       // (0,0 )
        }

    }
}
