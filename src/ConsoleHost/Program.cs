using ConsoleHost;

if(args.Length == 0)
{
    args = new string[1];
    args[0] = "sort";
}
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
    default:
        var sortRunner = new SortRunner();
        sortRunner.Run();
        break;
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();