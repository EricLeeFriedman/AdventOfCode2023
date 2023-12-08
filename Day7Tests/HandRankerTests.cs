using Day7;

namespace Day7Tests;

public class HandRankerTests
{
    [Fact]
    public void FiveOfAKindIsRankedHigherThanFourOfAKind()
    {
        // Arrange
        Hand fiveOfAKind = new("AAAAA");
        Hand fourOfAKind = new("AAAAT");
        
        // Act
        HandRanker ranker = new(new Hand[] { fourOfAKind, fiveOfAKind });
        var rankedHands = ranker.OrderedHands.ToArray();
        
        // Arrange
        Assert.True(rankedHands[0].Equals(fiveOfAKind));
        Assert.True(rankedHands[1].Equals(fourOfAKind));
    }

    [Fact]
    public void MatchingRankHandsAreRankedByFirstHighCard()
    {
        // Arrange
        Hand hand1 = new("A2222");
        Hand hand2 = new("2KKKK");
        
        // Act
        HandRanker ranker = new(new Hand[] { hand2, hand1 });
        var rankedHands = ranker.OrderedHands.ToArray();
        
        // Arrange
        Assert.True(rankedHands[0].Equals(hand1));
        Assert.True(rankedHands[1].Equals(hand2));
        
    }
}