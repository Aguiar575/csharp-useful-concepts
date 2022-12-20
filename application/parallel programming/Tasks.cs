using System;
using System.Diagnostics;
using System.Threading.Tasks;

public class Program
{

    public static void Write(char c)
    {
        int i = 1000;
        while (i-- > 0)
        {
            Console.Write(c);
        }
    }

    public static void Write(object o)
    {
        int i = 1000;
        while (i-- > 0)
        {
            Console.Write(o);
        }
    }
    
    public static int TextLenght(object o)
    {
        Console.WriteLine($"Task with id {Task.CurrentId}");
        return o.ToString().Length;
    }

    public static void Main()
    {
        //in this way a task is created and started
        Task.Factory.StartNew(() => Write('.'));

        //here we need to start it
        var aTask = new Task(() => Write('?'));
        aTask.Start();

        var anotherTask = new Task(Write, "Hello");
        anotherTask.Start();

        Console.WriteLine($"\n---------\n");

        string textOne = "testing", textTwo = "that";
        var taskOneLenght = new Task<int>(() => TextLenght(textOne));
        taskOneLenght.Start();

        Task<int> taskTwoLenght = Task.Factory.StartNew(TextLenght, textTwo);

        Console.WriteLine($"Text one length {taskOneLenght}");
        Console.WriteLine($"Text two length {taskTwoLenght}");

        Console.WriteLine("The task was finished");
    }
}