namespace Day2
{
    internal class CubeSet
    {
        public int RedCount { get; }

        public int BlueCount { get; }

        public int GreenCount { get; }

        public CubeSet(string input)
        {
            var cubes = input.Split(',', StringSplitOptions.TrimEntries);
            foreach (var cube in cubes)
            {
                var cubeParts = cube.Split(' ', StringSplitOptions.TrimEntries);
                var number = int.Parse(cubeParts[0]);
                var color = cubeParts[1];
                switch (color)
                {
                    case "red":
                        RedCount = number;
                        break;
                    case "blue":
                        BlueCount = number;
                        break;
                    case "green":
                        GreenCount = number;
                        break;
                    default:
                        throw new Exception("Unexpected Input");
                }
            }
        }
    }
}
