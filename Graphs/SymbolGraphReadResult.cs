using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class SymbolGraph
    {
        private readonly Dictionary<string, int> _symbols;
        private readonly string[] _keys;


        public SymbolGraph(Dictionary<string, int> symbols, string[] keys, Graph graph)
        {
            _symbols = symbols;
            _keys = keys;
            Graph = graph;
        }

        public Graph Graph { get; private set; }

        public bool Contains(string s) => _symbols.ContainsKey(s);

        public int Index(string s) => _symbols[s];

        public string Name(int v) => _keys[v];

    }
}

