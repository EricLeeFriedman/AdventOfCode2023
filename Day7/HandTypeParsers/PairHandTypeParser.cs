namespace Day7.HandTypeParsers;

public class PairHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType { get; } = Hand.HandType.OnePair;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() == 2);
    }
}