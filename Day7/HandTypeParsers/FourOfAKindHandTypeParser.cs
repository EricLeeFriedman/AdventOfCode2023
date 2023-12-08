namespace Day7.HandTypeParsers;

public class FourOfAKindHandTypeParser : IHandTypeParser
{
    public Hand.HandType HandType => Hand.HandType.FourOfAKind;
    public bool IsMatch(string input)
    {
        return input.GroupBy(c => c).Any(g => g.Count() == 4);
    }
}