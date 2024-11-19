using Simulator;
namespace TestSimulator;

public class ValidatorTests
{
    [Theory]
    [InlineData(5, 0, 10, 5)]
    [InlineData(-1, 0, 10, 0)]
    [InlineData(15, 0, 10, 10)]
    public void Limiter_ShouldReturnCorrectValue(int value, int min, int max, int expected)
    {
        var result = Validator.Limiter(value, min, max);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("abc", 5, 10, '-', "Abc--")]
    [InlineData("  abc  ", 3, 10, '-', "Abc")]
    [InlineData("abcabcabcabcabcabcabcabcabcabc", 5, 10, '-', "Abcabcabca")]
    public void Shortener_ShouldReturnCorrectString(string value, int min, int max, char placeholder, string expected)
    {
        var result = Validator.Shortener(value, min, max, placeholder);
        Assert.Equal(expected, result);
    }
}