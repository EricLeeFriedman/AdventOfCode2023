using Day7;

namespace Day7Tests;

public class JokerConverterTests
{
    [Fact]
    public void TwoPairWithAJokerIsRankedHigherThanThreeOfAKind()
    {
        // Arrange
        Hand twoPairWithAJoker = new("AAKKJ");
        Hand threeOfAKind = new("AAAKQ");
        
        // Act
        JokerConverter converter = new();
        twoPairWithAJoker = JokerConverter.Convert(twoPairWithAJoker);
        threeOfAKind = JokerConverter.Convert(threeOfAKind);
        HandRanker ranker = new(new Hand[] { threeOfAKind, twoPairWithAJoker });
        var rankedHands = ranker.OrderedHands.ToArray();
        
        // Arrange
        Assert.True(rankedHands[0].Equals(twoPairWithAJoker));
        Assert.True(rankedHands[1].Equals(threeOfAKind));
    }
}