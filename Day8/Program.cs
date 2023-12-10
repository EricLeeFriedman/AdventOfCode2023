using Day8;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");
var map = new Map(puzzleInput);
var steps = map.Traverse();

Console.WriteLine($"It takes {steps} steps to get to ZZZ.");
File.WriteAllText("PuzzleOutput1.txt", steps.ToString());

var steps2 = map.TraversePart2();

Console.WriteLine($"It takes {steps2} steps to get all coordinates to end in a Z.");
File.WriteAllText("PuzzleOutput2.txt", steps2.ToString());
