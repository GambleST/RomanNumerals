using System.Text;
using System.Text.RegularExpressions;

namespace RomanNumerals;

public class RomanNumeralConverter
{
    private readonly Dictionary<int, string> _intToNumeralDictionary = new()
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
    
    private readonly Dictionary<string, int> _numeralToIntDictionary = new()
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
            var highestPossibleInteger = _intToNumeralDictionary.Keys
                .Where(x => x <= numberToConvert)
                .Max();

            // Subtract the number key from the number being converted
            numberToConvert -= highestPossibleInteger;

            // Append the value (numerals) to the current string
            stringBuilder.Append(_intToNumeralDictionary[highestPossibleInteger]);
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
            throw new ArgumentException("Input contains invalid numerals.", nameof(formattedStringToConvert));
        
        var numberValue = 0;
        var validNumeralValues = _numeralToIntDictionary.Keys.ToList();

        var i = 0;
        while (i < formattedStringToConvert.Length)
        {
            if (i + 1 < formattedStringToConvert.Length)
            {
                var doubleNumerals = formattedStringToConvert.Substring(i, 2);
                if (validNumeralValues.Any(combination => String.Equals(doubleNumerals, combination)))
                {
                    i += 2;
                    numberValue += _numeralToIntDictionary[doubleNumerals];
                    continue;
                }
            }
            
            var singleNumeral = formattedStringToConvert.Substring(i, 1);
            if (validNumeralValues.Any(combination => String.Equals(singleNumeral, combination)))
            {
                i += 1;
                numberValue += _numeralToIntDictionary[singleNumeral];
            }
        }
        
        return numberValue;
    }
}