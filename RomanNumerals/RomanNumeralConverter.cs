using System.Text;
using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumeralConverter
{
    private static readonly Dictionary<int, string> IntToNumeralDictionary = new()
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

    private static readonly Dictionary<string, int> NumeralToIntDictionary = new()
    {
        { "M", 1000 },
        { "CM", 900 },
        { "D", 500 },
        { "CD", 400 },
        { "C", 100 },
        { "XC", 90 },
        { "L", 50 },
        { "XL", 40 },
        { "X", 10 },
        { "IX", 9 },
        { "V", 5 },
        { "IV", 4 },
        { "I", 1 }
    };

    public string ConvertToRomanNumerals(int numberToConvert)
    {
        if (numberToConvert is <= 0 or >= 4000)
            throw new ArgumentOutOfRangeException(nameof(numberToConvert), "Value must be between 1 and 3999.");

        var stringBuilder = new StringBuilder();
        while (numberToConvert > 0)
        {
            var highestPossibleInteger = IntToNumeralDictionary.Keys
                .Where(x => x <= numberToConvert)
                .Max();

            // Subtract the number key from the number being converted
            numberToConvert -= highestPossibleInteger;

            // Append the value (numerals) to the current string
            stringBuilder.Append(IntToNumeralDictionary[highestPossibleInteger]);
        }

        var result = stringBuilder.ToString();
        return result;
    }

    public int ConvertFromRomanNumerals(string stringToConvert)
    {
        if (String.IsNullOrWhiteSpace(stringToConvert))
            throw new ArgumentException("Input cannot be null or empty.", nameof(stringToConvert));

        var formattedStringToConvert = stringToConvert.ToUpper().Trim();
        if (!Regex.IsMatch(formattedStringToConvert, @"^[IVXLCDM]+$"))
            throw new ArgumentException("Input contains invalid numerals.", nameof(stringToConvert));

        var numberValue = 0;
        var i = 0;
        while (i < formattedStringToConvert.Length)
        {
            // Try a two-character combination first (e.g., "CM", "IV")
            if (i + 1 < formattedStringToConvert.Length &&
                NumeralToIntDictionary.TryGetValue(formattedStringToConvert.Substring(i, 2), out var numeralPair))
            {
                numberValue += numeralPair;
                i += 2;
                continue;
            }

            // Try a one-character symbol (e.g., "M", "D", "C")
            if (NumeralToIntDictionary.TryGetValue(formattedStringToConvert.Substring(i, 1), out var numeralSingle))
            {
                numberValue += numeralSingle;
                i += 1;
                continue;
            }

            // If neither matched, input is malformed
            throw new ArgumentException("Input contains an invalid Roman numeral sequence.", nameof(stringToConvert));
        }
        
        
        // Convert the parsed number back to Roman Numerals and ensure it matches the correct form.
        var correctRomanNumeralString = ConvertToRomanNumerals(numberValue);
        if (!String.Equals(correctRomanNumeralString, formattedStringToConvert, StringComparison.Ordinal))
        {
            throw new ArgumentException("Input is not a valid Roman numeral sequence.", nameof(stringToConvert));
        }

        return numberValue;
    }
}