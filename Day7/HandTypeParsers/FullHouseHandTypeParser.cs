namespace Day7.HandTypeParsers;

public class FullHouseHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType { get; } = Hand.HandType.FullHouse;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() == 3) && input.GroupBy(c => c).Any(g => g.Count() == 2);
    }
}