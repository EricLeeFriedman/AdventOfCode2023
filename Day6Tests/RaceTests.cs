using Day6;

namespace Day6Tests;

public class RaceTests
{
    [Fact]
    public void SevenRaceTime9BestDistanceReturns4Options()
    {
        // Arrange
        var race = new Race(7, 9);
        
        // Act
        var options = race.GetWinningOptions();
        
        // Assert
        Assert.Equal(4, options.Count());
    }

    [Fact]
    public void FifteenRaceTime40BestDistanceReturns8Options()
    {
        // Arrange
        var race = new Race(15, 40);
        
        // Act
        var options = race.GetWinningOptions();
        
        // Assert
        Assert.Equal(8, options.Count());
    }

    [Fact]
    public void ThirtyRaceTime200BestDistanceReturns9Options()
    {
        // Arrange
        var race = new Race(30, 200);
        
        // Act
        var options = race.GetWinningOptions();
        
        // Assert
        Assert.Equal(9, options.Count());
    }
}