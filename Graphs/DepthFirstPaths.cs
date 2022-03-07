using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public sealed class DepthFirstPaths : GraphSearch
    {
        private int[] _edgeTo;
        private readonly int _source;

        public DepthFirstPaths(Graph g, int source) : base(g)
        {
            _source = source;
        }

        public override void Search(int v)
        {
            if (v < _marked.Length)
            {
                _marked[v] = true;
                foreach(var w in _g.Adjacent(v))
                {
                    _edgeTo[w] = v;
                    Search(w);
                }
            }
                
        }

        public bool HasPathTo(int v)
        {
            return _marked[v];
        }

        public IEnumerable<int> PathTo(int v)
        {
            if (!HasPathTo(v)) return Enumerable.Empty<int>();
            var path = new Stack<int>();
            for(int x = v; x != _source; x = _edgeTo[x])
            {
                path.Push(x);
            }
            path.Push(_source);
            return path;
        }
    }
}
