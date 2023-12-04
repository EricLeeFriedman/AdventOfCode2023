namespace Day3
{
    internal class GridNumber(int number, int startPosition, int length)
    {
        public int Number { get; } = number;
        public int StartPosition { get; } = startPosition;
        public int Length { get; } = length;
    }
}