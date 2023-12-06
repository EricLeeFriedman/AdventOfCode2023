namespace Day5;

public class Map
{
    private readonly List<Tuple<long, long, long>> _map = new();
    
    public void Add(long destination, long source, long range)
    {
        _map.Add(new Tuple<long, long, long>(source, destination, range));
    }
    
    public long Get(long source)
    {
        foreach (var (start, destination, range) in _map)
        {
            if (source >= start && source <= start + (range-1))
            {
                return destination + (source - start);
            }
        }
        return source;
    }
}