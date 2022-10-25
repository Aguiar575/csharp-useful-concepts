public static class Switch
{
    public static void SwitchPatternMatching()
    {
        int hardCodedValue = 13;
        string result = hardCodedValue switch
        {
            13 => "Okay",
            14 => "None",
            _ => "Default"
        };

        Console.WriteLine(hardCodedValue);
    }
}