using System;
using System.Threading;
using System.Threading.Tasks;

public class Program
{
    public static void Main()
    {
        var cts = new CancellationTokenSource();
        var cancellationToken = cts.Token;

        //creating event to notify the
        //cancellation of task
        cancellationToken.Register(() => 
        {
            Console.Writeline("Cancellation has been requested");
        });

        var infiniteTask = new Task(() => 
        {
            int i = 0;
            while(true) 
            {
                // if(cts.IsCancellationRequested) 
                //     break;
                // else
                //     Console.Writeline($"{i++}");

                //the task status is changed to canceled    
                cancellationToken.ThrowIfCancellationRequested();
                Console.Writeline($"{i++}");
            }
        }, cancellationToken);

        infiniteTask.Start();

        Console.ReadKey();
        cts.Cancel();
    }
}