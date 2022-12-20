using System;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

public class Program
{
    SpinLock sl = new SpinLock(true);
    
    public static void LockRecursion(int x) 
    {
        bool lockTaken = false;
        
        try 
        {
            sl.Enter(ref lockTaken);
        }
        catch(LockRecursionException ex) 
        {
            Console.WriteLine(ex);
        }
        finally 
        {
            if(lockTaken)
            {
                Console.WriteLine($"took a lock, x = {x}");
                LockRecursion(x-1);
                sl.Exit();
            } else 
            {
                Console.WriteLine($"failed to take a lock, x = {x}");
            }
        }
    }
 
    public static void Main()
    {
        LockRecursion(5);
    }
}