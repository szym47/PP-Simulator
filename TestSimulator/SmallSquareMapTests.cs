using Simulator;
using Simulator.Maps;
namespace TestSimulator;

public class SmallSquareMapTests
{
    [Fact]
    public void Constructor_ValidSize_ShouldSetSize()
    {
        int size = 10;
        var map = new SmallSquareMap(size);
        Assert.Equal(size, map.Size);
    }

    [Theory]
    [InlineData(4)]
    [InlineData(21)]
    public void Constructor_InvalidSize_ShouldThrowArgumentOutOfRangeException(int size)
    {
        int invalidSize = size;
        Action act = () => new SmallSquareMap(invalidSize);
        Assert.Throws<ArgumentOutOfRangeException>(act);
    }


    [Theory]
    [InlineData(3, 4, 5, true)]
    [InlineData(-1, 0, 10, false)]
    [InlineData(9, 9, 10, true)]
    [InlineData(10, 10, 10, false)]
    public void Exist_ShouldReturnCorrectValue(int x, int y, int size, bool expected)
    {
        var map = new SmallSquareMap(size);
        var point = new Point(x, y);
        var result = map.Exist(point);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Next_PointInsideMap_ShouldReturnNextPoint()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(5, 5);
        var nextPoint = map.Next(point, Direction.Up);
        Assert.Equal(new Point(5, 6), nextPoint);
    }

    [Fact]
    public void Next_PointOutsideMap_ShouldReturnSamePoint()
    {
        var map = new SmallSquareMap(10);
        var point = new Point(9, 9);
        var nextPoint = map.Next(point, Direction.Up);
        Assert.Equal(point, nextPoint);
    }
}