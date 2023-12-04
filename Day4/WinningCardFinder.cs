namespace Day4;

public class WinningCardFinder
{
    public int NumberOfMatchingNumbers { get; private set;  } = 0;
    private readonly List<int> _winningNumbers;
    private readonly List<int> _scratchedNumbers;
    
    public WinningCardFinder(List<int> winningNumbers, List<int> scratchedNumbers)
    {
        _winningNumbers = winningNumbers;
        _scratchedNumbers = scratchedNumbers;
        ParseMatchingNumbers();
    }

    private void ParseMatchingNumbers()
    {
        NumberOfMatchingNumbers = _scratchedNumbers.Count(number => _winningNumbers.Contains(number));
    }
    
}