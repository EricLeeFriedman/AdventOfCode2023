// See https://aka.ms/new-console-template for more information

using Day2;


var puzzleInputLines = File.ReadAllLines("PuzzleInput.txt");

List<Game> games = new();
foreach (var input in puzzleInputLines)
{
    games.Add(new Game(input));
}

const int RedCubes = 12;
const int GreenCubes = 13;
const int BlueCubes = 14;

var puzzleSum = 0;
foreach (var game in games)
{
    if (game.IsValidGame(RedCubes, GreenCubes, BlueCubes))
    {
        puzzleSum += game.GameId;
    }
}

Console.WriteLine($"Puzzle Sum: {puzzleSum}");

var puzzlePowerSum = 0;
foreach (var game in games)
{
    puzzlePowerSum += game.MinimumRedCubes * game.MinimumGreenCubes * game.MinimumBlueCubes;
}

Console.WriteLine($"Puzzle Power Sum: {puzzlePowerSum}");