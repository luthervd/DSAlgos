using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Paths
    {
        private Graph _g;
        public Paths(Graph g, int s)
        {
            _g = g;

        }

        public bool HasPathTo(int v)
        {
            return false;
        }

        public IEnumerable<int> PathTo(int v)
        {
            return _g.Adjacent(v);
        }
    }
}
