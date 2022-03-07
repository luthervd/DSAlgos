using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class DepthFirstSearch
    {
        private List<bool> _marked;
        private int _count;

        public DepthFirstSearch(Graph g, int s)
        {
            _marked = new List<bool>(g.Vertices);
            _count = 0;
            DFS(g, s);  
        }


        private void DFS(Graph g, int v)
        {
            _marked[v] = true;
            _count++;
            foreach(var w in g.Adjacent(v))
            {
                if (!_marked[w])
                {
                    DFS(g, w);
                }
            }
        }
        public bool Marked(int v)
        {
            return _marked[v];
        }

        public int Count()
        {
            return 0;   
        }
    }
}
