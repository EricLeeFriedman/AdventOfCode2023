namespace Day8;

public class Map
{
    public List<int> Instructions { get; } = [];
    public Dictionary<string, Tuple<string, string>> Coordinates { get; } = new();
    private List<string> _startingCoordinates = [];
    
    public Map(string[] input)
    {
        ParseInstructions(input);
        ParseCoordinates(input);
    }

    private void ParseCoordinates(string[] input)
    {
        var coordinateLines = input.Skip(2);
        foreach (var coordinateLine in coordinateLines)
        {
            var coordinate = coordinateLine.Split(" = ");
            var coordinateName = coordinate[0];
            var coordinateValue = coordinate[1];
            var coordinateTuple = coordinateValue.Trim('(', ')').Split(", ");
            var coordinateX = coordinateTuple[0];
            var coordinateY = coordinateTuple[1];
            Coordinates.Add(coordinateName, new Tuple<string, string>(coordinateX, coordinateY));

            if (coordinateName.EndsWith('A'))
            {
                _startingCoordinates.Add(coordinateName);
            }
        }
    }

    private void ParseInstructions(string[] input)
    {
        Dictionary<char, int> instructionMap = new()
        {
            {'L', 0},
            {'R', 1},
        };
        var instructionLine = input[0].Trim();
        foreach (var instruction in instructionLine)
        {
            Instructions.Add(instructionMap[instruction]);
        }
    }

    public int Traverse()
    {
        var instructionIndex = 0;
        var steps = 0;
        var currentCoordinate = "AAA";
        while (currentCoordinate != "ZZZ")
        {
            var currentInstruction = Instructions[instructionIndex];
            var currentCoordinateTuple = Coordinates[currentCoordinate];
            currentCoordinate = currentInstruction switch
            {
                0 => currentCoordinateTuple.Item1,
                1 => currentCoordinateTuple.Item2,
                _ => throw new Exception("Invalid instruction")
            };
            steps++;
            
            if (++instructionIndex >= Instructions.Count)
            {
                instructionIndex = 0;
            }
        }

        return steps;
    }
    
    private static Int128 GreatestCommonDivisor(Int128 a, Int128 b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    private static Int128 LeastCommonMultiple(Int128 a, Int128 b)
    {
        if (a >= b) return a * b / GreatestCommonDivisor(a, b);
        return a * b / GreatestCommonDivisor(b, a);
    }
    
    public Int128 TraversePart2()
    {
        var instructionIndex = 0;
        var steps = 0;
        var currentCoordinate = _startingCoordinates;
        List<Int128> firstZIndex = [];
        for (var index = 0; index < currentCoordinate.Count; index++)
        {
            firstZIndex.Add(-1);
        }
        while (!firstZIndex.All(z => z >= 0))
        {
            var currentInstruction = Instructions[instructionIndex];
            for (var index = 0; index < currentCoordinate.Count; index++)
            {
                var coordinate = currentCoordinate[index];

                if (coordinate.EndsWith('Z') && firstZIndex[index] < 0)
                {
                    firstZIndex[index] = steps;
                }
                
                var currentCoordinateTuple = Coordinates[coordinate];
                currentCoordinate[index] = currentInstruction switch
                {
                    0 => currentCoordinateTuple.Item1,
                    1 => currentCoordinateTuple.Item2,
                    _ => throw new Exception("Invalid instruction")
                };
            }
            steps++;
            if (++instructionIndex >= Instructions.Count)
            {
                instructionIndex = 0;
            }
        }

        return firstZIndex.Aggregate<Int128, Int128>(1, LeastCommonMultiple);
    }
}