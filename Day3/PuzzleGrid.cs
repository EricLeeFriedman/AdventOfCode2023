namespace Day3
{
    internal class PuzzleGrid
    {
        private readonly List<GridLine> _lines = new List<GridLine>();
        
        public PuzzleGrid(string[] puzzleInput)
        {
            GridLine? previousLine = null;

            for (var i = 0; i < puzzleInput.Length; i++)
            {
                var nextLine = (i + 1) < puzzleInput.Length ? new GridLine(puzzleInput[i + 1]) : null;
                var newLine = new GridLine(puzzleInput[i])
                {
                    PreviousLine = previousLine,
                    NextLine = nextLine
                };
                _lines.Add(newLine);
                previousLine = newLine;
            }
        }

        public IEnumerable<int> GetPartNumbers()
        {
            var partNumbers = new List<int>();
            foreach (var line in _lines)
            {
                partNumbers.AddRange(line.GetPartNumbers());
            }

            return partNumbers;
        }
        
        public IEnumerable<int> GetGearRatios()
        {
            var gearRatios = new List<int>();
            foreach (var line in _lines)
            {
                gearRatios.AddRange(line.GetGearRatios());
            }

            return gearRatios;
        }
    }
}
