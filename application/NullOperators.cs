using System.Text;

public static class NullOperators
{
    public static void Coalescing()
    {
        string s1 = null;
        string s2 = s1 ?? "nothing";
        Console.WriteLine(s2);
    }

    public static void CoalescingAssignmet()
    {
        string s1 = null;
        string defaultValue = "default";

        s1 ??= defaultValue;

        //equivalent to
        //if(s1 == null) s1 = defaultValue
    }

    public static void CoalescingElvis()
    {
        StringBuilder sb = null;
        string s = sb?.ToString(); //No errors here
    }
}