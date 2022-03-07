using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class GraphArgs
    {
        public int Vertices { get; set; }

        public int Edges { get; set; }

        public ICollection<(int First,int Second)> EdgeArgs { get; set; } = new List<(int First,int Second)> ();
    }
}
