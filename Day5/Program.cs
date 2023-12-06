using Day5;

var puzzleInput = File.ReadAllLines("PuzzleInput.txt");

var inputIndex = 3;

var seedToSoilMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref seedToSoilMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var soilToFertilizerMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref soilToFertilizerMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var fertilizerToWaterMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref fertilizerToWaterMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var waterToLightMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref waterToLightMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var lightToTemperatureMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref lightToTemperatureMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var temperatureToHumidityMap = new Map();
while (puzzleInput[inputIndex] != "")
{
    AddToMap(ref temperatureToHumidityMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var humidityToLocationMap = new Map();
while (inputIndex < puzzleInput.Length && puzzleInput[inputIndex] != "")
{
    AddToMap(ref humidityToLocationMap, puzzleInput[inputIndex].Split(" "));
    inputIndex++;
}
inputIndex += 2;

var seeds = puzzleInput[0].Split(":")[1].Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToList();
var smallestNumber = long.MaxValue;

foreach (var seed in seeds)
{
    var soil = seedToSoilMap.Get(seed);
    var fertilizer = soilToFertilizerMap.Get(soil);
    var water = fertilizerToWaterMap.Get(fertilizer);
    var light = waterToLightMap.Get(water);
    var temperature = lightToTemperatureMap.Get(light);
    var humidity = temperatureToHumidityMap.Get(temperature);
    var location = humidityToLocationMap.Get(humidity);
    if (location < smallestNumber)
    {
        smallestNumber = location;
    }
}

Console.WriteLine($"Part 1: The smallest number is {smallestNumber}");

smallestNumber = long.MaxValue;
for (var index = 0; index < seeds.Count; index += 2)
{
    var seedRange = seeds[index + 1];
    for (var seed = 0; seed < seedRange; ++seed)
    {
        var soil = seedToSoilMap.Get(seeds[index] + seed);
        var fertilizer = soilToFertilizerMap.Get(soil);
        var water = fertilizerToWaterMap.Get(fertilizer);
        var light = waterToLightMap.Get(water);
        var temperature = lightToTemperatureMap.Get(light);
        var humidity = temperatureToHumidityMap.Get(temperature);
        var location = humidityToLocationMap.Get(humidity);
        if (location < smallestNumber)
        {
            smallestNumber = location;
        }
    }
}

Console.WriteLine($"Part 2: The smallest number is {smallestNumber}");

return;

void AddToMap(ref Map map, string[] split)
{
    var destination = long.Parse(split[0]);
    var source = long.Parse(split[1]);
    var range = long.Parse(split[2]);
    map.Add(destination, source, range);
}