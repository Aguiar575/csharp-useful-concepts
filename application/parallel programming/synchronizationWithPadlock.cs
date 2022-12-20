using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace synchrnization;

public class BankAccount
{
    public object Padlock = new object();
    public int Balance { get; private set; }

    public void Deposit(int amount)
    {
        lock (Padlock)
        {
            Balance += amount;
        }
    }

    public void Withdraw(int amount)
    {
        lock (Padlock)
        {
            Balance -= amount;
        }
    }
}

public class Program
{
    public static void Main()
    {
        var tasks = new List<Task>();
        var ba = new BankAccount();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    ba.Deposit(100);
                }
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    ba.Withdraw(100);
                }
            }));
        }

        Task.WaitAll(tasks.ToArray());
        Console.Writeline($"Final balance is: {ba.Balance}");
    }
}