using Simulator;
namespace TestSimulator;

public class PointTests
{
    [Fact]
    public void Constructor_ShouldSetCoordinatesCorrectly()
    {
        var point = new Point(5, 10);
        Assert.Equal(5, point.X);
        Assert.Equal(10, point.Y);
    }

    [Fact]
    public void Next_ValidDirection_ShouldReturnCorrectPoint()
    {
        var point = new Point(5, 5);
        var result = point.Next(Direction.Up);
        Assert.Equal(new Point(5, 6), result);
    }

    [Fact]
    public void NextDiagonal_ValidDirection_ShouldReturnCorrectPoint()
    {
        var point = new Point(5, 5);
        var result = point.NextDiagonal(Direction.Up);
        Assert.Equal(new Point(6, 6), result);
    }
}