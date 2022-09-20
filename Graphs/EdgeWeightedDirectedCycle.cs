using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class EdgeWeightedDirectedCycle
    {
        private bool[] _marked;
        private DirectedWeightedEdge[] _edgeTo;
        private Stack<DirectedWeightedEdge> _cycle;
        private bool[] _onStack;

        public EdgeWeightedDirectedCycle(EdgeWeightedDiGraph digraph)
        {
            _onStack = new bool[digraph.Vertices];
            _cycle = new Stack<DirectedWeightedEdge>();
            _marked = new bool[digraph.Vertices];
            _edgeTo = new DirectedWeightedEdge[digraph.Vertices];
            for (var i = 0; i < digraph.Vertices; i++)
            {
                if (!_marked[i])
                {
                    Dfs(digraph, i);
                }
            }
        }

        private void Dfs(EdgeWeightedDiGraph digraph, int v)
        {
            _onStack[v] = true;
            _marked[v] = true;
            foreach (var node in digraph.Adjacent(v))
            {
                var w = node.To;
                if (HasCycle)
                {
                    return;
                }
                else if (!_marked[w])
                {
                    _edgeTo[w] = node;
                    Dfs(digraph, w);
                }
                else if (_onStack[w])
                {
                    var f = node;
                    while (f?.From != null && f.From != w)
                    {
                        _cycle.Push(f);
                        f = _edgeTo[f.From];
                    }
                    _cycle.Push(f);
                    return;
                }
            }
            _onStack[v] = false;
        }

        public bool HasCycle => _cycle.Any();

        public IEnumerable<DirectedWeightedEdge> Cycle => _cycle;
    }
}
