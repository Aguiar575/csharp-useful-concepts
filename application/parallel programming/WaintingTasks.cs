using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var cts = CancellationTokenSource();
        var token = cts.Token;

        var taskOne = newTask(() =>
        {
            Console.Writeline("I take 5 seconds");

            for (int i = 0; i < 5; i++)
            {
                token.ThrowIfCancellationRequested();
                Thread.Sleep(1000);
            }
        }, token);
        taskOne.Start();

        Task taskTwo = Task.Factory.StartNew(() => Thread.Sleep(3000), token);

        //Task.WaitAll(taskOne, taskTwo);
        Task.WaitAny(new[] {taskOne, taskTwo}, 4000, token);
        
        Console.Writeline($"{taskOne.Status}");
        Console.Writeline($"{taskTwo.Status}");

        Console.ReadKey();
        token.Cancel();

    }
}