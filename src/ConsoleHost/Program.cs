using System.Diagnostics;
using Trees;

string ValueFactory()
{
    return "This is value for key ";
}

//Seed
Console.WriteLine("Generating ....");
var seedCount = 10;
var searchKey = seedCount;
var values = new (int, string)[seedCount];
var valueSeed = Stopwatch.StartNew();
for (int i = 0; i < seedCount; i++)
{
    values[i] = (i + 1, $"{ValueFactory()}{i + 1}");
}
valueSeed.Stop();
Console.WriteLine($"Seed took {valueSeed.ElapsedTicks} ticks");

//Randomise
var random = new Random();
var randomSeed = Stopwatch.StartNew();
var randomised = values.OrderBy(x => random.Next(10000)).ToArray();
randomSeed.Stop();
Console.WriteLine($"Randomise took {randomSeed.ElapsedTicks} ticks");



var binaryTree = new BinarySearchTree<int, string>();
var binarySeed = Stopwatch.StartNew();
foreach (var item in randomised)
{
    if (!binaryTree.TryAdd(item.Item1, item.Item2))
    {
        throw new Exception("Error in add");
    }
}
binarySeed.Stop();
Console.WriteLine($"Binary seed took {binarySeed.ElapsedTicks}");

//Start search
Console.WriteLine($"Array has {values.Count()}");
Console.WriteLine($"Random BinarySearchTree has {binaryTree.Count}");
Console.WriteLine($"Random BinarySearchTree has {binaryTree.LeftFromRootCount} on the Left");
Console.WriteLine($"Random BinarySearchTree has {binaryTree.RightFromRootCount} on the Right");
Console.WriteLine($"Binary tree has height {binaryTree.Height}");
Console.WriteLine("Starting search from ordered Array");

var arrayStopWatch = Stopwatch.StartNew();
var orderSteps = 0;
for (int i = 0; i < values.Length; i++)
{
    if (values[i].Item1.Equals(searchKey))
    {
        arrayStopWatch.Stop();
        orderSteps = i;
    }
}
Console.WriteLine($"Ordered array took {arrayStopWatch.ElapsedTicks} ticks and {orderSteps + 1} iterations");

Console.WriteLine("Starting search from random Array");
var randomStopWatch = Stopwatch.StartNew();
var randomSteps = 0;
for (int i = 0; i < randomised.Length; i++)
{
    if (randomised[i].Item1.Equals(searchKey))
    {
        randomSteps = i;
        randomStopWatch.Stop();
    }
}
Console.WriteLine($"Randomised array took {randomStopWatch.ElapsedTicks} ticks and {randomSteps + 1} iterations");

Console.WriteLine("Starting search from random Array");
var steps = 0;
var binTreeStopWatch = Stopwatch.StartNew();
var found = binaryTree.TryGetValue(searchKey, out var value, ref steps);
binaryTree.Delete(4);
binTreeStopWatch.Stop();


if (!found) { throw new Exception("Shit just got real"); }
Console.WriteLine($"BinarySearchTree found {value}");
Console.WriteLine($"BinaryTree took {binTreeStopWatch.ElapsedTicks} ticks and {steps} iterations");
Console.ReadKey();

var fixedValues = new (int, int)[10] { (5, 5), (2,2), (6, 6), (3, 3), (7, 7), (1, 1), (8, 8), (4, 4),(9,9),(10,10) };

var tree = new BinarySearchTree<int, int>();
foreach (var fixedValue in fixedValues)
{
    tree.TryAdd(fixedValue.Item1, fixedValue.Item2);
}
tree.Delete(2);
var steps2 = 0;
var found2 = tree.TryGetValue(3,out var _, ref steps2);
Console.ReadKey();
