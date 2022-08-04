using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs.Trees
{
    public class DirectedWeightedEdge
    {
        private readonly int _fromV;
        private readonly int _toV;
        private readonly double _weight;

        public DirectedWeightedEdge(int fromV, int toV, double weight)
        {
            _fromV = fromV;
            _toV = toV;
            _weight = weight;
        }

        public int From => _fromV;

        public int To => _toV;
        public double Weight => _weight;

        public override string ToString() => $"{From}->{To} {_weight:0.##}";
    }
}
