using Day7;

namespace Day7Tests;

public class HandTests
{
    [Fact]
    public void HandWithoutAMatchReturnsHighCard()
    {
        // Arrange
        
        // Act
        var hand = new Hand("23456");
        
        // Arrange
        Assert.Equal(Hand.HandType.HighCard, hand.Type);
    }
    
    [Fact]
    public void HandWithOneMatchReturnsOnePair()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22345");
        
        // Arrange
        Assert.Equal(Hand.HandType.OnePair, hand.Type);
    }
    
    [Fact]
    public void HandWithTwoMatchesReturnsTwoPair()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22334");
        
        // Arrange
        Assert.Equal(Hand.HandType.TwoPair, hand.Type);
    }
    
    [Fact]
    public void HandWithThreeMatchesReturnsThreeOfAKind()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22234");
        
        // Arrange
        Assert.Equal(Hand.HandType.ThreeOfAKind, hand.Type);
    }
    
    [Fact]
    public void HandWithThreeMatchesAndAPairReturnsFullHouse()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22233");
        
        // Arrange
        Assert.Equal(Hand.HandType.FullHouse, hand.Type);
    }
    
    [Fact]
    public void HandWithFourMatchesReturnsFourOfAKind()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22223");
        
        // Arrange
        Assert.Equal(Hand.HandType.FourOfAKind, hand.Type);
    }
    
    [Fact]
    public void HandWithFiveMatchesReturnsFiveOfAKind()
    {
        // Arrange
        
        // Act
        var hand = new Hand("22222");
        
        // Arrange
        Assert.Equal(Hand.HandType.FiveOfAKind, hand.Type);
    }
}