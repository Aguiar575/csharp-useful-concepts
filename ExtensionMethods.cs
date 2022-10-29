public static class StringHelper
{
    public static bool IsCaptalized(this string s)
    {
        if(string.IsNullOrEmpty(s)) return false;
        return char.IsUpper(s[0]);
    }
}