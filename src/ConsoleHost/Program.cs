using ConsoleHost;

if(args.Length == 0)
{
   Console.WriteLine("Arg required");
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
    default:
        var graphRunner = new GraphRunner();
        graphRunner.Run();
        break;
}

Console.WriteLine("Press any key to exit");
Console.ReadKey();