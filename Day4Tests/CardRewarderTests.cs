using Day4;

namespace Day4Tests;

public class CardRewarderTests
{
    [Fact]
    public void DefaultRewarderThatStartsWith6CardsHas6Cards()
    {
        // Arrange
        
        // Act
        CardRewarder rewarder = new(6);

        // Assert
        Assert.Equal(6, rewarder.CardCount);
    }

    [Fact]
    public void RewarderThatStartsWith6CardsAndFirstOneHasThreeWinningNumbersNowHas9Cards()
    {
        // Arrange
        CardRewarder rewarder = new(6);
        
        // Act
        rewarder.TrackWinningNumbers(0, 3);
        
        // Assert
        Assert.Equal(9, rewarder.CardCount);
    }

    [Fact]
    public void MultiplierEffectWorks()
    {
        // Arrange
        CardRewarder rewarder = new(6);
        
        // Act
        rewarder.TrackWinningNumbers(0, 3);
        rewarder.TrackWinningNumbers(1, 2);
        
        // Assert
        Assert.Equal(13, rewarder.CardCount);
    }
    
}