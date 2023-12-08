namespace Day7.HandTypeParsers;

public interface IHandTypeParser
{
    public Hand.HandType HandType { get; }
    public bool IsMatch(string input);
}