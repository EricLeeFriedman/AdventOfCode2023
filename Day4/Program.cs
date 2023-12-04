using Day4;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");
var winningCardFinders = new WinningCardFinder[puzzleInput.Length];

var sum = 0;
for (var index = 0; index < puzzleInput.Length; index++)
{
    var line = puzzleInput[index];
    var cardParser = new CardParser(line);
    winningCardFinders[index] = new WinningCardFinder(cardParser.WinningNumbers, cardParser.ScratchedNumbers);
    if (winningCardFinders[index].NumberOfMatchingNumbers > 0)
    {
        sum += (int)Math.Pow(2, (double)winningCardFinders[index].NumberOfMatchingNumbers - 1);
    }
}

Console.WriteLine($"The sum of all winning cards is {sum}.");

var cardRewarder = new CardRewarder(puzzleInput.Length);
for (var index = 0; index < winningCardFinders.Length; index++)
{
    cardRewarder.TrackWinningNumbers(index, winningCardFinders[index].NumberOfMatchingNumbers);
}

Console.WriteLine($"The total number of cards is {cardRewarder.CardCount}.");