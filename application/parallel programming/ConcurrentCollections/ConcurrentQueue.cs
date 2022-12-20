using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var q = new ConcurrentQueue<int>();
        q.Enqueue(1);
        q.Enqueue(2);

        if(q.TryDequeue(out int result))
        {
            Console.WriteLine($"Removed element {result}");
        }

        if(q.TryDequeue(out int result))
        {
            Console.WriteLine($"front element is {result}");
        }
    }
}