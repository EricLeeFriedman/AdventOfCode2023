using Day4;

namespace Day4Tests;

public class CardParserTests
{
    [Fact]
    public void ParseLinePullsCorrectWinningNumbers()
    {
        // Arrange
        const string line = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
        
        // Act
        CardParser parser = new(line);
        
        // Assert
        Assert.Equal(new List<int> {41, 48, 83, 86, 17}, parser.WinningNumbers);
    }

    [Fact]
    public void ParseLinePullsCorrectScratchedNumbers()
    {
        // Arrange
        const string line = "Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53";
        
        // Act
        CardParser parser = new(line);
        
        // Assert
        Assert.Equal(new List<int> {83, 86, 6, 31, 17, 9, 48, 53}, parser.ScratchedNumbers);
    }
}