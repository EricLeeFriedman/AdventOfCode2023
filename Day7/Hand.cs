using Day7.HandTypeParsers;

namespace Day7;

public class Hand : IComparable
{
    public enum HandType
    {
        HighCard,
        OnePair,
        TwoPair,
        ThreeOfAKind,
        FullHouse,
        FourOfAKind,
        FiveOfAKind,
    }
    
    public HandType Type { get; set; }
    public string Cards { get; private set; }
    private readonly List<IHandTypeParser> _handTypeParsers = new()
    {
        new FiveOfAKindHandTypeParser(),
        new FourOfAKindHandTypeParser(),
        new FullHouseHandTypeParser(),
        new ThreeOfAKindHandTypeParser(),
        new TwoPairHandTypeParser(),
        new PairHandTypeParser(),
    };
    
    public Hand(string input)
    {
        Cards = input;
        foreach (var handTypeParser in _handTypeParsers.Where(handTypeParser => handTypeParser.IsMatch(input)))
        {
            Type = handTypeParser.HandType;
            break;
        }
    }

    public int CompareTo(object? obj)
    {
        throw new NotImplementedException();
    }
}