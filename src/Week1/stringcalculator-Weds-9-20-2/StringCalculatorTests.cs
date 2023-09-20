
namespace StringCalculator;

public class StringCalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new StringCalculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("108", 108)]
    public void SingleDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("10,18", 28)]
    [InlineData("108,200", 308)]
    public void TwoDigits(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]
    public void ArbitraryLengthNumbers(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2\n3", 6)]
    [InlineData("1,2\n3,1", 7)]
    public void MixedDelimeters(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//;\n1;2", 3)]
    [InlineData("//;\n1;2;1", 4)]

    public void CustomDelimeters(string numbers, int expected)
    {
        var calculator = new StringCalculator();
        var result = calculator.Add(numbers);
        Assert.Equal(expected, result);
    }

    [Theory]

    [InlineData("-1")]
    [InlineData("1,2,3,4,5,6,7,8,900,-300,1000")]
    [InlineData("1,2,3,4,5,6,7,8\n900,-300,1000")]
    [InlineData("//-\n1-2-1")]
    public void NegativeNumbersNotAllowed(string numbers)
    {
        var calculator = new StringCalculator();

        Assert.Throws<NoNegativeNumbersException>(() => calculator.Add(numbers));
    }
}
