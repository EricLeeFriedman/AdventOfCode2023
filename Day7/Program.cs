using Day7;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");

List<Tuple<Hand, int>> handsWithBets = [];

foreach (var line in puzzleInput)
{
    var splitLine = line.Split(' ');
    var hand = new Hand(splitLine[0]);
    var bet = int.Parse(splitLine[1]);
    handsWithBets.Add(new Tuple<Hand, int>(hand, bet));
}

// Part 2 Addition:
handsWithBets = handsWithBets.Select(tuple => new Tuple<Hand, int>(JokerConverter.Convert(tuple.Item1), tuple.Item2)).ToList();
// End of Part 2 Addition

var ranker = new HandRanker(handsWithBets.Select(tuple => tuple.Item1));
var orderedHands = ranker.OrderedHands.ToArray();

var points = 0;
for (var index = 0; index < orderedHands.Length; index++)
{
    var hand = orderedHands[index];
    var bet = handsWithBets.First(h => h.Item1 == hand).Item2;
    points += bet * (orderedHands.Length - index);
}

Console.WriteLine($"Total points: {points}");
