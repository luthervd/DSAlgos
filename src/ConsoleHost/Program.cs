using ConsoleHost;

switch (args[0])
{
    case "t":
    case "tree":
        var treeRunner = new TreeRunner();
        treeRunner.Run();
        break;
    case "g":
    case "graph":
        var graphRunner = new GraphRunner();
        graphRunner.Run();
        break;
}