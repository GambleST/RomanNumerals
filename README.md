# Roman Numerals Converter

A simple **.NET 8 console application** and accompanying **xUnit test suite** for converting between integers and Roman numerals.  
Built as part of a small technical challenge, focusing on correctness, readability, and maintainability.

---

## 🧩 Overview

The project provides a single class, `RomanNumeralConverter`, which supports:

- ✅ Conversion from integers (1–3999) to Roman numerals
- ✅ Conversion from valid Roman numerals to their integer value
- ✅ Validation (rejects invalid or non-standard forms)
- ✅ Full test coverage with xUnit

---

## 🧱 Project Structure

```
RomanNumerals/
├── RomanNumerals/
│   ├── RomanNumeralConverter.cs   # Core converter logic
│   ├── Program.cs                 # Example entry point
│   └── RomanNumerals.csproj       # .NET 8 console project
│
└── RomanNumerals.Tests/
    ├── RomanNumeralsFunctionTests.cs  # xUnit test suite
    └── RomanNumerals.Tests.csproj
```

---

## 🚀 Getting Started

### Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/download)

### Build & Run
```bash
# Restore dependencies
dotnet restore

# Build the project
dotnet build

# Run the console app
dotnet run --project RomanNumerals
```

The main entry point (`Program.cs`) shows a simple example:
```csharp
using RomanNumerals;

var converter = new RomanNumeralConverter();
Console.WriteLine(converter.ConvertToRomanNumerals(2022));  // MMXXII
Console.WriteLine(converter.ConvertFromRomanNumerals("MCMXC")); // 1990
```

---

## 🧪 Running Tests

The test suite uses **xUnit** and covers valid, invalid, and edge cases.

```bash
dotnet test
```

---

## ⚙️ Design Notes

- **Static dictionaries** for fast lookup both ways
- **Regex validation** ensures only Roman numeral characters are accepted
- **End Validation check** prevents non-standard sequences
- Fully **unit tested** (including round-trip and invalid sequence tests)

---

## 📂 Example Output

```
> dotnet run
MMXXII
1990
```

---

## 🧾 License

This project is provided for educational and demonstration purposes.

---

**Author:** Steven Gamble  
**Language:** C# (.NET 8)  
**Test Framework:** xUnit
