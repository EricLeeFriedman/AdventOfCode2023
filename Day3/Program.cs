using Day3;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");

var puzzleGrid = new PuzzleGrid(puzzleInput);
var partNumbers = puzzleGrid.GetPartNumbers();
var part1Answer = partNumbers.Sum();

Console.WriteLine($"Part 1: {part1Answer}");

var part2Answer = puzzleGrid.GetGearRatios().Sum();
Console.WriteLine($"Part 2: {part2Answer}");