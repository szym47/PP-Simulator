using System.Drawing;

namespace Simulator;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Starting Simulator!\n");
        Point p = new(10, 25);
        Console.WriteLine(p.Next(Direction.Right));          // (11, 25)
        Console.WriteLine(p.NextDiagonal(Direction.Right));  // (11, 26)
        Console.WriteLine();
        Lab5a();
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
                Point p3 = new Point(5,5);
                Point p4 = new Point(5, 10);
                Rectangle rect4 = new Rectangle(p3,p4);
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
}
