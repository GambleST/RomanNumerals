namespace RomanNumerals.Tests.UnitTests;

public class RomanNumeralsFunctionTests
{
    [Theory]
    [InlineData(2022, "MMXXII")]
    [InlineData(1990, "MCMXC")]
    [InlineData(2008, "MMVIII")]
    [InlineData(1666, "MDCLXVI")]
    [InlineData(3999, "MMMCMXCIX")]
    public void ConvertToRomanNumerals_WhenCalledWithValidInput_ReturnsExpectedString(int input, string expectedOutput)
    {
        // Arrange
        var converter = new RomanNumeralConverter();
        
        // Act
        var result = converter.ConvertToRomanNumerals(input);
        
        // Assert
        Assert.Equal(expectedOutput, result);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(4000)]
    [InlineData(-1)]
    public void ConvertToRomanNumerals_WhenCalledWithInvalidInput_ThrowsException(int invalidInput)
    {
        // Arrange
        var converter = new RomanNumeralConverter();
        
        // Act & Assert
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => converter.ConvertToRomanNumerals(invalidInput));
        Assert.Contains("1 and 3999", ex.Message);
    }
    
    [Theory]
    [InlineData(2022)]
    [InlineData(3999)]
    [InlineData(4)]
    public void ConvertToRomanNumerals_WhenCalledTwiceWithSameInput_ReturnsSameOutput(int input)
    {
        var converter = new RomanNumeralConverter();

        var first = converter.ConvertToRomanNumerals(input);
        var second = converter.ConvertToRomanNumerals(input);

        Assert.Equal(first, second);
    }
}