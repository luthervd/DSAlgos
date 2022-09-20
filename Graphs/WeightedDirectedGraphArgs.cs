using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs;

public class WeightedDirectedGraphArgs
{
    public int Vertices { get; set; }

    public int Edges { get; set; }

    public ICollection<(int From, int To, double Weight)> EdgeArgs { get; set; } = new List<(int From, int To, double Weight)>();

    public IEnumerable<DirectedWeightedEdge> EdgeItems => EdgeArgs.Select(x => new DirectedWeightedEdge(x.From, x.To, x.Weight)).ToList();
}
