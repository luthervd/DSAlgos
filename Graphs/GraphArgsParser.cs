﻿namespace Graphs;

public class GraphArgsParser
{
    public GraphArgs ReadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException("No such file");
        }
        var index = 0;
        var graphArgs = new GraphArgs();
        foreach (var line in File.ReadLines(path))
        {
            
            if(index < 2)
            {
                if(index == 0)
                {
                    graphArgs.Vertices = int.Parse(line);
                }
                else graphArgs.Edges = int.Parse(line); 
            }
            else
            {
                var args = line.Trim().Split(" ");
                graphArgs.EdgeArgs.Add((int.Parse(args[0]), int.Parse(args[1])));
            }
           
            index++;
        }
        return graphArgs;
    }
}
