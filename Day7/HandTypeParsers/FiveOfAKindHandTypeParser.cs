namespace Day7.HandTypeParsers;

public class FiveOfAKindHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType { get; } = Hand.HandType.FiveOfAKind;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() == 5);
    }
}