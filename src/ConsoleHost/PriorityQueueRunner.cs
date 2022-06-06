using Sorting.Queues;

namespace ConsoleHost;

public class PriorityQueueRunner
{
    public void Run()
    {
        var items = new List<int> { 8, 4, 6, 5, 2, 3, 9, 10 };

        Console.WriteLine("Max queue");
        var maxPq = new PriorityQueue<int>(items.Count, QueueWeighting.Max);
        foreach(var item in items)
        {
            maxPq.Insert(item);
        }
        while (!maxPq.IsEmpty())
        {
            var highest = maxPq.Dequeue();
            Console.WriteLine($"Max item is {highest}");
        }
        Console.WriteLine("Min queue");
        var minPq = new PriorityQueue<int>(items.Count, QueueWeighting.Min);
        foreach (var item in items)
        {
            minPq.Insert(item);
        }
        while (!minPq.IsEmpty())
        {
            var highest = minPq.Dequeue();
            Console.WriteLine($"Max item is {highest}");
        }
    }
}
