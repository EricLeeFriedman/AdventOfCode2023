using System.Diagnostics;
using Day6;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");

var part1Times = puzzleInput[0].Split(":")[1].Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
var part1BestDistances = puzzleInput[1].Split(":")[1].Split(new char[] {' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();

if (part1Times.Length != part1BestDistances.Length) throw new Exception("Times and best distances must be the same length");

var part1Races = new Race[part1Times.Length];
for (var index = 0; index < part1Times.Length; ++index)
{
    part1Races[index] = new Race(part1Times[index], part1BestDistances[index]);
}

var part1Total = 1;
foreach (var race in part1Races)
{
    part1Total *= race.GetWinningOptions().Count();
}

Console.WriteLine($"Part 1: Total winning options: {part1Total}");

var part2Time = long.Parse(part1Times.Aggregate("", (current, number) => current + number.ToString()));
var part2Distance = long.Parse(part1BestDistances.Aggregate("", (current, number) => current + number.ToString()));

Console.WriteLine($"Part 2:  Time and Distance: {part2Time} {part2Distance}");
Console.WriteLine($"Part 2: Total winning options: {new Race(part2Time, part2Distance).GetWinningOptions().Count()}");
