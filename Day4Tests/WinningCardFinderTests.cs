using Day4;

namespace Day4Tests;

public class WinningCardFinderTests
{
    [Fact]
    public void FourMatchingNumbersReturnsFour()
    {
        // Arrange
        var winningNumbers = new List<int> { 41, 48, 83, 86, 17 };
        var scratchedNumbers = new List<int> { 83, 86, 6, 31, 17, 9, 48, 53 };
        
        // Act
        WinningCardFinder finder = new(winningNumbers, scratchedNumbers);
        
        // Assert
        Assert.Equal(4, finder.NumberOfMatchingNumbers);
    }
    
    [Fact]
    public void TwoMatchingNumbersReturnsTwo()
    {
        // Arrange
        var winningNumbers = new List<int> { 13, 32, 20, 16, 61 };
        var scratchedNumbers = new List<int> { 61, 30, 68, 82, 17, 32, 24, 19 };
        
        // Act
        WinningCardFinder finder = new(winningNumbers, scratchedNumbers);
        
        // Assert
        Assert.Equal(2, finder.NumberOfMatchingNumbers);
    }
    
}