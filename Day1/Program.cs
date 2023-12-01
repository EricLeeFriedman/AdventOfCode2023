var puzzleInputLines = File.ReadAllLines("PuzzleInput.txt");

var numbersToSum = new int[puzzleInputLines.Length];
var numberIndex = 0;

foreach (var line in puzzleInputLines)
{
    var firstNumber = FindFirstNumber(line);
    var secondNumber = FindLastNumber(line);
    numbersToSum[numberIndex++] = int.Parse(firstNumber + secondNumber);
}

var sum = numbersToSum.Sum();
Console.WriteLine($"Sum: {sum}");

return;

#if false 

// Part 1
static string FindFirstNumber(string input)
{
    foreach (var character in input)
    {
        if (int.TryParse(character.ToString(), out var number))
        {
            return character.ToString();
        }
    }
    throw new Exception("Unexpected Input");
}

static stringFindLastNumber(string input)
{
    for (var i = input.Length - 1; i >= 0; i--)
    {
        if (int.TryParse(input[i].ToString(), out var number))
        {
            return input[i].ToString();
        }
    }
    throw new Exception("Unexpected Input");
}

// End of Part 1
#else 

// Part 2

static bool NumberConvertor(string input, out string output)
{
    var numberDictionary = new Dictionary<string, string>
    {
        { "one", "1" },
        { "two", "2" },
        { "three", "3" },
        { "four", "4" },
        { "five", "5" },
        { "six", "6" },
        { "seven", "7" },
        { "eight", "8" },
        { "nine", "9" },
    };

    foreach (var t in numberDictionary)
    {
        if (!input.ToLower().Contains(t.Key.ToLower())) continue;
        output = t.Value;
        return true;
    }

    output = "";
    return false;

}

static string FindFirstNumber(string input)
{
    var stringBuilder = "";
    foreach (var character in input)
    {
        if (int.TryParse(character.ToString(), out var number))
        {
            return character.ToString();
        }
        stringBuilder += character;
        if (NumberConvertor(stringBuilder, out var numberString))
        {
            return numberString;
        }
    }
    throw new Exception("Unexpected Input");
}

static string FindLastNumber(string input)
{
    var stringBuilder = "";
    for (var i = input.Length - 1; i >= 0; i--)
    {
        if (int.TryParse(input[i].ToString(), out var number))
        {
            return input[i].ToString();
        }

        stringBuilder = stringBuilder.Insert(0, input[i].ToString());
        if (NumberConvertor(stringBuilder, out var numberString))
        {
            return numberString;
        }
    }
    throw new Exception("Unexpected Input");
}

// End of Part 2
#endif 
