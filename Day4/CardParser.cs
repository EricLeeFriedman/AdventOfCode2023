namespace Day4;

public class CardParser
{
    public List<int> WinningNumbers { get; } = new();
    public List<int> ScratchedNumbers { get; } = new();
    
    public CardParser(string line)
    {
        ParseWinningNumbers(line);
        ParseScratchedNumbers(line);
    }
    
    private void ParseWinningNumbers(string line)
    {
        var splitLine = line.Split(":");
        var winningNumbers = splitLine[1].Split("|")[0].Split(" ").Where(n => !string.IsNullOrWhiteSpace(n));
        winningNumbers.ToList().ForEach(number => WinningNumbers.Add(int.Parse(number)));
    }
    
    private void ParseScratchedNumbers(string line)
    {
        var splitLine = line.Split(":");
        var scratchedNumbers = splitLine[1].Split("|")[1].Split(" ").Where(n => !string.IsNullOrWhiteSpace(n));
        scratchedNumbers.ToList().ForEach(number => ScratchedNumbers.Add(int.Parse(number)));
    }
}