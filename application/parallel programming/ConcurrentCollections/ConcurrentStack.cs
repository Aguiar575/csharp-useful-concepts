using System;
using System.Threading.Tasks;
using System.Collections.Concurrent;

public class Program
{
    private static ConcurrentDictionary<string, string> capitals = 
        new ConcurrentDictionary<string, string>();
    
    public static void AddParis() {
        capitals.TryAdd("France", "Paris");
        string who = Task.CurrentId.HasValue ? ("Task " + Task.CurrentId) : "Main thread";
        Console.WriteLine(who);
    }

    
    public static void Main()
    {
        Task.Factory.StartNew(AddParis).Wait();
        AddParis();       

        capitals["Russia"] = "Leningrad";
        capitals.AddOrUpdate("Russia", "Moscow", 
        (_, old) => old + " --> Moscow");
        Console.WriteLine(capitals["Russia"]);

        capitals["Sweden"] = "Uppsala";
        var capitalOfSwedwn = capitals.GetOrAdd("Sweden", "Stockholm");
        Console.WriteLine(capitals["Sweden"]);

        const string toRemove = "Russia";
        var didRemove = capitals.TryRemove(toRemove, out string removed);
        Console.WriteLine($"{removed}, have been removed? {didRemove}");
    }
}