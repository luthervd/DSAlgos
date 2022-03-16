using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class ConnectedComponentDFS
    {
        private int[] _id;
        private bool[] _marked;
        private Graph _g;
        

        public ConnectedComponentDFS(Graph g)
        {
            _marked = new bool[g.Vertices];
            _id = new int[g.Vertices];
            _g = g;
        }
        
        public List<List<int>> Run()
        {
            for(var i = 0; i < _g.Vertices; i++)
            {
                if (!_marked[i])
                {
                    DFS(i);
                    Count++;
                }
            }
            var results = new Dictionary<int, List<int>>();
            for(var i = 0; i < _id.Length; i++)
            {
                if (!results.ContainsKey(_id[i]))
                {
                    results[_id[i]] = new List<int> { i };
                }
                else
                {
                    results[_id[i]].Add(i);
                }
            }
            return results.Values.ToList();
       
        }

        
        private void DFS(int s)
        {
            _marked[s] = true;
            _id[s] = Count;
            foreach(int v in _g.Adjacent(s))
            {
                if (!_marked[v])
                {
                    DFS(v);
                }
            }
        }

        public int Count {  get; private set; }
    }
}
