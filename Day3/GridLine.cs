namespace Day3
{
    internal class GridLine
    {
        private string Line { get; }
        public GridLine? PreviousLine { get; set; }
        public GridLine? NextLine { get; set; }
        private readonly List<GridNumber> _numbers = new List<GridNumber>();
        private readonly List<int> _gears = new List<int>();
        
        public GridLine(string line)
        {
            Line = line;
            ParseNumbers();
            ParseGears();
        }

        private void ParseNumbers()
        {
            var numberBuilder = "";
            int numberStart = 0;
            int numberLength = 0;

            for (int i = 0; i < Line.Length; i++)
            {
                var character = Line[i];
                if (char.IsDigit(character))
                {
                    if (string.IsNullOrEmpty(numberBuilder))
                    {
                        numberStart = i;
                    }

                    numberBuilder += character;
                    ++numberLength;
                }
                
                else if (!string.IsNullOrEmpty(numberBuilder))
                {
                    var number = int.Parse(numberBuilder);
                    _numbers.Add(new GridNumber(number, numberStart, numberLength));
                    numberBuilder = "";
                    numberLength = 0;
                }
            }

            if (!string.IsNullOrEmpty(numberBuilder))
            {
                var number = int.Parse(numberBuilder);
                _numbers.Add(new GridNumber(number, numberStart, numberLength));
            }
        }

        private void ParseGears()
        {
            for (var i = 0; i < Line.Length; i++)
            {
                var character = Line[i];
                if (character == '*')
                {
                    _gears.Add(i);
                }
            }
        }
        
        private static bool IsSymbol(char character)
        {
            return !char.IsDigit(character) && character != '.';
        }

        private bool HasSymbolInRange(int start, int end)
        {
            for (var i = start; i <= end; i++)
            {
                if (i < 0 || i >= Line.Length)
                {
                    continue;
                }
                
                if (IsSymbol(Line[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<int> GetPartNumbers()
        {
            var partNumbers = new List<int>();
            foreach (var number in _numbers)
            {
                var startPosition = number.StartPosition - 1;
                var endPosition = number.StartPosition + number.Length;
                if (PreviousLine != null)
                {
                    if (PreviousLine.HasSymbolInRange(startPosition, endPosition))
                    {
                        partNumbers.Add(number.Number);
                        continue;
                    }
                }

                if (HasSymbolInRange(startPosition, endPosition))
                {
                    partNumbers.Add(number.Number);
                    continue;
                }
                
                if (NextLine != null)
                {
                    if (NextLine.HasSymbolInRange(startPosition, endPosition))
                    {
                        partNumbers.Add(number.Number);
                        continue;
                    }
                }
            }

            return partNumbers;
        }
        
        private IEnumerable<int> GetNumbersAdjacentToIndex(int index)
        {
            var adjacentNumbers = new List<int>();
            foreach (var number in _numbers)
            {
                var startPosition = number.StartPosition - 1;
                var endPosition = number.StartPosition + number.Length;
                
                if (index >= startPosition && index <= endPosition)
                {
                    adjacentNumbers.Add(number.Number);
                }
            }
            return adjacentNumbers;
        }

        public IEnumerable<int> GetGearRatios()
        {
            var gearRatios = new List<int>();
            
            foreach (var gear in _gears)
            {
                var gearRatio = 0;
                var adjacentNumbers = new List<int>();
                
                if (PreviousLine != null)
                {
                    adjacentNumbers.AddRange(PreviousLine.GetNumbersAdjacentToIndex(gear));
                }

                adjacentNumbers.AddRange(GetNumbersAdjacentToIndex(gear));
                
                if (NextLine != null)
                {
                    adjacentNumbers.AddRange(NextLine.GetNumbersAdjacentToIndex(gear));
                }

                if (adjacentNumbers.Count == 2)
                {
                    gearRatios.Add(adjacentNumbers[0] * adjacentNumbers[1]);
                }
            }
            return gearRatios;
        }
    }
}
