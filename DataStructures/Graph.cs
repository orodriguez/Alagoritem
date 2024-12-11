namespace DataStructures;

public class Graph<T> where T : notnull
{
    private readonly Dictionary<T, List<T>> _edges;

    public Graph() => _edges = new Dictionary<T, List<T>>();

    public IEnumerable<IEnumerable<T>> Paths(T start, T end) => 
        Paths(Array.Empty<T>(), start, end);

    private IEnumerable<IEnumerable<T>> Paths(IEnumerable<T> prefix, T start, T end)
    {
        if (!_edges.ContainsKey(start))
            return Array.Empty<IEnumerable<T>>();

        if (start.Equals(end))
            return new[] { prefix.Concat(new[] { start }) };

        return _edges[start]
            .Where(node => !prefix.Contains(node))
            .Select(node => Paths(prefix.Concat(new[] { start} ),node, end))
            .SelectMany(paths => paths);
    }

    public void Add(T start, T end)
    {
        if (!_edges.ContainsKey(start))
            _edges[start] = new List<T>();

        if (!_edges.ContainsKey(end))
             _edges[end] = new List<T>();
        
        _edges[start].Add(end);
    }
}