namespace Graphs;

public class WeightedGraphArgsParser
{
    public WeightedGraphArgs ReadFromFile(string path)
    {
        if (!File.Exists(path))
        {
            throw new ArgumentException("No such file");
        }
        var index = 0;
        var graphArgs = new WeightedGraphArgs();
        foreach (var line in File.ReadLines(path))
        {

            if (index == 0)
            {
                var topArgs = line.Split(' ');
                graphArgs.Vertices = int.Parse(topArgs[0]);
                graphArgs.Edges = int.Parse(topArgs[1]);
            }
            else
            {
                var args = line.Trim().Split(" ");
                graphArgs.EdgeArgs.Add((int.Parse(args[0]), int.Parse(args[1]), double.Parse(args[2])));
            }

            index++;
        }
        return graphArgs;
    }

    public WeightedDirectedGraphArgs ReadDirectedFromFile(string path)
    {

        if (!File.Exists(path))
        {
            throw new ArgumentException("No such file");
        }
        var index = 0;
        var graphArgs = new WeightedDirectedGraphArgs();
        foreach (var line in File.ReadLines(path))
        {

            if (index == 0)
            {
                var topArgs = line.Split(' ');
                graphArgs.Vertices = int.Parse(topArgs[0]);
                graphArgs.Edges = int.Parse(topArgs[1]);
            }
            else
            {
                var args = line.Trim().Split(" ");
                graphArgs.EdgeArgs.Add((int.Parse(args[0]), int.Parse(args[1]), double.Parse(args[2])));
            }

            index++;
        }
        return graphArgs;
    }
}
