namespace Day7.HandTypeParsers;

public class ThreeOfAKindHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType { get; } = Hand.HandType.ThreeOfAKind;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() == 3);
    }
}