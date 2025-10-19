using System.Text;

namespace RomanNumerals;

public class RomanNumeralConverter
{
    private readonly Dictionary<int, string> _validNumerals = new()
    {
        { 1000, "M" },
        { 900, "CM" },
        { 500, "D" },
        { 400, "CD" },
        { 100, "C" },
        { 90, "XC" },
        { 50, "L" },
        { 40, "XL" },
        { 10, "X" },
        { 9, "IX" },
        { 5, "V" },
        { 4, "IV" },
        { 1, "I" }
    };

    public string ConvertToRomanNumerals(int numberToConvert)
    {
        if (numberToConvert is <= 0 or >= 4000)
            throw new ArgumentOutOfRangeException(nameof(numberToConvert), "Value must be between 1 and 3999.");

        var stringBuilder = new StringBuilder();
        while (numberToConvert > 0)
        {
            var highestPossibleInteger = _validNumerals.Keys
                .Where(x => x <= numberToConvert)
                .Max();

            // Subtract the number key from the number being converted
            numberToConvert -= highestPossibleInteger;

            // Append the value (numerals) to the current string
            stringBuilder.Append(_validNumerals[highestPossibleInteger]);
        }

        var result = stringBuilder.ToString();
        return result;
    }
}