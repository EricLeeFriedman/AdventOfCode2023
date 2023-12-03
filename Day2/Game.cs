namespace Day2
{
    internal class Game
    {
        public int GameId { get; }

        private readonly List<CubeSet> _cubeSets = new();

        public int MinimumRedCubes { get; } = 0;
        public int MinimumBlueCubes { get; } = 0;
        public int MinimumGreenCubes { get; } = 0;

        public Game(string input)
        {
            var gameAndSets = input.Split(':', StringSplitOptions.TrimEntries);
            var idStart = 5; // "Game "
            var idLength = gameAndSets[0].Length - idStart;
            var gameId = gameAndSets[0].Substring(idStart, idLength);
            GameId = int.Parse(gameId);

            var cubeSets = gameAndSets[1].Split(';', StringSplitOptions.TrimEntries);
            foreach (var cubeSet in cubeSets)
            {
                _cubeSets.Add(new CubeSet(cubeSet));
            }

            foreach (var cubeSet in _cubeSets)
            {
                if (cubeSet.RedCount > MinimumRedCubes)
                {
                    MinimumRedCubes = cubeSet.RedCount;
                }

                if (cubeSet.BlueCount > MinimumBlueCubes)
                {
                    MinimumBlueCubes = cubeSet.BlueCount;
                }

                if (cubeSet.GreenCount > MinimumGreenCubes)
                {
                    MinimumGreenCubes = cubeSet.GreenCount;
                }
            }
        }

        public bool IsValidGame(int maxRedCubes, int maxGreenCubes, int maxBlueCubes)
        {
            return _cubeSets.All(cubeSet => cubeSet.RedCount <= maxRedCubes && cubeSet.GreenCount <= maxGreenCubes && cubeSet.BlueCount <= maxBlueCubes);
        }
    }
}
