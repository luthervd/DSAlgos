using ConsoleHost;

var sortRunner = new SortRunner();
sortRunner.Run();
var treeRunner = new TreeRunner();
treeRunner.Run();
var graphRunner = new GraphRunner();
graphRunner.Run();

Console.WriteLine("Press any key to exit");
Console.ReadKey();