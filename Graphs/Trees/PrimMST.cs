using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Trees
{
    public class PrimMST
    {
        private WeightedEdge[] edgeTo; // shortest edge from tree vertex
        private double[] distTo; // distTo[w] = edgeTo[w].weight()
        private bool[] marked; // true if v on tree
        private PriorityQueue<int,double> pq;
        private EdgeWeightedGraph _graph;

        private PrimMST(EdgeWeightedGraph graph)
        {
            _graph = graph;
            edgeTo = new WeightedEdge[graph.V];
            distTo = new double[graph.V];
            marked = new bool[graph.V];
            pq = new PriorityQueue<int,double>(graph.V);
            for(var i =0; i < distTo.Length; i++)
            {
                distTo[i] = double.PositiveInfinity;
            }
            distTo[0] = 0.0;
            pq.Enqueue(0, 0.0);

        }

        public static PrimMST Build(EdgeWeightedGraph graph)
        {
            var primMst = new PrimMST(graph);
            while (primMst.pq.Count > 0)
            {
                primMst.Visit(primMst.pq.Dequeue());
            }
            return primMst;
        }
        private void Visit(int v)
        {
            marked[v] = true;
            foreach(var edge in _graph.Adj(v))
            {
                //var w = edge.Other(v);
                //if(marked[w])
                //{
                //    continue;
                //}
                //if(edge.Weight < distTo[w])
                //{
                //    edgeTo[w] = edge;
                //    distTo[w] = edge.Weight;
                //    if(pq.)
                //}
            }
        }

    }
}
