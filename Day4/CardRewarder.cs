namespace Day4;

public class CardRewarder
{
    public int CardCount => _cardCounts.Sum();
    private readonly List<int> _cardCounts;
    
    public CardRewarder(int cardCount)
    {
        _cardCounts = new List<int>(cardCount);
        _cardCounts.AddRange(Enumerable.Repeat(1, cardCount));
    }
    
    public void TrackWinningNumbers(int cardIndex, int numberOfWinningNumbers)
    {
        for (var index = 0; index < numberOfWinningNumbers; index++)
        {
            if (cardIndex + 1 + index < _cardCounts.Count)
            {
                _cardCounts[cardIndex + 1 + index] += _cardCounts[cardIndex];
            }
        }
    }
}