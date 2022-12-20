using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace synchrnization;

public class BankAccount
{
    private int balance;

    public int Balance
    {
        get { return balance; }
        private set { balance = value; }
    }

    public void Deposit(int amount) => 
        balance += amount;

    public void Withdraw(int amount) =>
        balance -= amount;
}

public class Program
{
    public static void Main()
    {
        var tasks = new List<Task>();
        var ba = new BankAccount();

        SpinLock sl = new SpinLock();

        for (int i = 0; i < 10; i++)
        {
            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    var lockTaken = false;
                    try 
                    {
                        sl.Enter(ref lockTaken);
                        ba.Deposit(100);
                    }
                    finally
                    {
                        if(lockTaken) sl.Exit();
                    }
                }
            }));

            tasks.Add(Task.Factory.StartNew(() =>
            {
                for (int j = 0; j < 1000; j++)
                {
                    var lockTaken = false;
                    try 
                    {
                        sl.Enter(ref lockTaken);
                        ba.Withdraw(100);
                    }
                    finally
                    {
                        if(lockTaken) sl.Exit();
                    }
                }
            }));
        }

        Task.WaitAll(tasks.ToArray());
        Console.Writeline($"Final balance is: {ba.Balance}");
    }
}