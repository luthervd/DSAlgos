using System;

namespace Graphs
{
    public class Graph
    {
        private List<int>[] adj;

        public Graph(int numberOfVertices)
        {
            Vertices = numberOfVertices;
            Edges = 0;
            adj = new List<int>[numberOfVertices];
            for(int i = 0; i < numberOfVertices; i++)
            {
                adj[i] = new List<int>();   
            }
        }

        public Graph(GraphArgs args) : this(args.Vertices)
        {
            Edges = args.Edges;
            foreach(var edgeArg in args.EdgeArgs)
            {
                AddEdge(edgeArg.First, edgeArg.Second);
            }
        }

        public int Vertices { get; }

        public int Edges { get; set; }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w); // Add w to v’s list.
            adj[w].Add(v); // Add v to w’s list.
            Edges++;
        }

        public IEnumerable<int> Adjacent(int vertice)
        {
            return  adj[vertice];
        }

        public override string ToString()
        {
            var s = Vertices + " vertices, " + Edges + " edges\n";
            for (int v = 0; v < Vertices; v++)
            {
                s += v + ": ";
                foreach(var w in adj[v])
                {
                    s += w + " ";
                }
                   
                s += "\n";
            }
            return s;
        }
    }
}
