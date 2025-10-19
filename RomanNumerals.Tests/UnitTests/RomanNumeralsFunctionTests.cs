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
    
    // D, L and V can never repeat and do not need to be validated.
    [Fact]
    public void ConvertToRomanNumerals_WhenCalledWithAllValues_NeverContainsFourIdenticalCharactersInARow()
    {
        // Arrange
        var converter = new RomanNumeralConverter();
        var invalidSequences = new[] { "IIII", "XXXX", "CCCC", "MMMM" };

        // Act & Assert
        for (int i = 1; i <= 3999; i++)
        {
            var result = converter.ConvertToRomanNumerals(i);

            foreach (var invalidSequence in invalidSequences)
            {
                Assert.DoesNotContain(invalidSequence, result);
            }
        }
    }


    [Theory]
    [InlineData("MMXXI", 2021)]
    [InlineData("MMXXII", 2022)]
    [InlineData("MCMXC", 1990)]
    [InlineData("MMVIII", 2008)]
    [InlineData("MDCLXVI", 1666)]
    [InlineData("MMMCMXCIX", 3999)]
    public void ConvertFromRomanNumerals_WhenCalledWithValidInput_ReturnsExpectedValue(string input, int expectedOutput)
    {
        // Arrange
        var converter = new RomanNumeralConverter();

        // Act
        var result = converter.ConvertFromRomanNumerals(input);

        // Assert
        Assert.Equal(expectedOutput, result);
    }
    
    [Theory]
    [InlineData("ABC")]
    [InlineData("MXZ")]
    [InlineData("123")]
    [InlineData("MCMXC@")]
    [InlineData("m m x x i")]
    public void ConvertFromRomanNumerals_WhenCalledWithInvalidString_ThrowsArgumentException(string invalidInput)
    {
        var converter = new RomanNumeralConverter();

        var ex = Assert.Throws<ArgumentException>(() => converter.ConvertFromRomanNumerals(invalidInput));
        Assert.Contains("invalid numerals", ex.Message);
    }
    
    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void ConvertFromRomanNumerals_WhenCalledWithNullOrEmptyString_ThrowsArgumentException(string invalidInput)
    {
        var converter = new RomanNumeralConverter();

        var ex = Assert.Throws<ArgumentException>(() => converter.ConvertFromRomanNumerals(invalidInput));
        Assert.Contains("null or empty", ex.Message);
    }
    
    [Theory]
    [InlineData("mmxxi", 2021)]
    [InlineData("MCMXC ", 1990)]
    [InlineData(" mmmcmxcix ", 3999)]
    public void ConvertFromRomanNumerals_WhenCalledWithUnformattedString_ReturnsValidInput(string unformattedInput, int expectedOutput)
    {
        // Arrange
        var converter = new RomanNumeralConverter();

        // Act
        var result = converter.ConvertFromRomanNumerals(unformattedInput);

        // Assert
        Assert.Equal(expectedOutput, result);
    }
    
    [Theory]
    [InlineData("IL")]     // 49 should be XLIX
    [InlineData("IC")]     // 99 should be XCIX
    [InlineData("VX")]     // invalid subtractive form
    [InlineData("IIV")]    // invalid repetition/subtractive
    [InlineData("VV")]     // V cannot repeat
    public void ConvertFromRomanNumerals_WhenCalledWithInValidNumeralInput_ThrowsArgumentException(string invalidNumeralInput)
    {
        // Arrange
        var converter = new RomanNumeralConverter();

        // Act & Assert
        var ex = Assert.Throws<ArgumentException>(() => converter.ConvertFromRomanNumerals(invalidNumeralInput));
        Assert.Contains("not a valid Roman numeral sequence", ex.Message, StringComparison.OrdinalIgnoreCase);
    }
}