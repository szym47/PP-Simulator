using Simulator;
namespace TestSimulator;

public class RectangleTests
{
    [Fact]
    public void Constructor_ValidCoordinates_ShouldCreateRectangle()
    {
        int x1 = 0;
        int y1 = 0;
        int x2 = 5;
        int y2 = 5;
        var rect = new Rectangle(x1, y1, x2, y2);
        Assert.Equal(0, rect.X1);
        Assert.Equal(0, rect.Y1);
        Assert.Equal(5, rect.X2);
        Assert.Equal(5, rect.Y2);
    }

    [Fact]
    public void Constructor_FlatRectangle_ShouldThrowException()
    {
        Assert.Throws<ArgumentException>(() => new Rectangle(0, 0, 0, 5));
    }

    [Fact]
    public void Contains_PointInsideRectangle_ShouldReturnTrue()
    {
        var rect = new Rectangle(0, 0, 5, 5);
        var point = new Point(3, 3);
        var result = rect.Contains(point);
        Assert.True(result);
    }

    [Fact]
    public void Contains_PointOutsideRectangle_ShouldReturnFalse()
    {
        var rect = new Rectangle(0, 0, 5, 5);
        var point = new Point(6, 6);
        var result = rect.Contains(point);
        Assert.False(result);
    }
}