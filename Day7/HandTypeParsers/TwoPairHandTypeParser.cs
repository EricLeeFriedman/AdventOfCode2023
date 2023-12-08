namespace Day7.HandTypeParsers;

public class TwoPairHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType { get; } = Hand.HandType.TwoPair;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Count(g => g.Count() == 2) == 2;
    }
}