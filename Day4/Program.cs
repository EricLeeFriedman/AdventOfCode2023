using Day4;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");

var sum = 0;
foreach (var line in puzzleInput)
{
    var cardParser = new CardParser(line);
    var winningCardFinder = new WinningCardFinder(cardParser.WinningNumbers, cardParser.ScratchedNumbers);
    if (winningCardFinder.NumberOfMatchingNumbers > 0)
    {
        sum += (int)Math.Pow(2, (double)winningCardFinder.NumberOfMatchingNumbers - 1);
    }
}

Console.WriteLine($"The sum of all winning cards is {sum}.");
