using RomanNumerals;

var converter = new RomanNumeralConverter();
Console.WriteLine(converter.ConvertToRomanNumerals(2022));  // MMXXII
Console.WriteLine(converter.ConvertFromRomanNumerals("MCMXC")); // 1990