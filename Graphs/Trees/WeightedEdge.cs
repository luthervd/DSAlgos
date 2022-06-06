namespace Graphs.Trees;

public struct WeightedEdge : IComparable<WeightedEdge>
{
    private readonly int _v;
    private readonly int _w;

    public WeightedEdge(int v, int w, double weight)
    {
        _v = v;
        _w = w;
        Weight = weight;
    }

    public double Weight { get; set; }

    public int Either()
    {
        return _v;
    }

    public int Other(int v)
    {
        if (v == _v) return _w;
        if (v == _w) return _v;
        throw new ArgumentException("Inconsitent Edge");
    }


    public int CompareTo(WeightedEdge other)
    {
        if (Weight < other.Weight) return -1;
        else if (Weight > other.Weight) return 1;
        else return 0;
    }

    public override string ToString()
    {
        return $"{_v}-{_w} {Weight}";
    }
}
