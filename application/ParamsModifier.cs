public static class ParamsModifier
{
    public static int SumBunchOfInts(params int[] ints)
    {
        int sum = 0;
        for (int i = 0; i < ints.Length; i++)
        {
            sum += ints[i];
        }

        return sum;
    }
}