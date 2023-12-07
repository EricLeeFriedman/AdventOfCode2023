namespace Day6;

public class Race(long raceTime, long bestDistance)
{
    private readonly long _raceTime = raceTime;
    private readonly long _bestDistance = bestDistance;
    
    public IEnumerable<Tuple<long, long>> GetWinningOptions()
    {
        var winningOptions = new List<Tuple<long, long>>();
        
        for (var holdTime = 1; holdTime < _raceTime - 1; holdTime++)
        {
            var timeToTravel = _raceTime - holdTime;
            var distance = holdTime * timeToTravel;

            if (distance > _bestDistance)
            {
                winningOptions.Add(new Tuple<long, long>(holdTime, distance));
            }
        }
        
        return winningOptions;
    }
}