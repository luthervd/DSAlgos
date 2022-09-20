namespace Graphs
{
    public static class SymbolGraphReader
    {
        public static SymbolGraph Read(string filePath, string seperator)
        {
            var symbols = new Dictionary<string, int>();
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var args = line.Split(seperator);
                for (int i = 0; i < args.Length; i++)
                {
                    if (!symbols.ContainsKey(args[i]))
                    {
                        symbols.Add(args[i], symbols.Count() - 1);
                    }
                }
            }
            var keys = new string[symbols.Count];
            foreach(var kv in symbols)
            {
                keys[kv.Value] = kv.Key;
            }
            var graph = new Graph(symbols.Count);
            foreach(var line in lines)
            {
                var args = line.Split(seperator);
                var v = symbols[args[0]];
                for(int i = 0; i < args.Length; i++)
                {
                    graph.AddEdge(v, symbols[args[i]]);
                }
            }

            return new SymbolGraph(symbols,keys,graph);
        }
    }
}
