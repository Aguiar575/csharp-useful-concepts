public static class SomeOperations
{
    public static int Square(int x) => x * x;
    public static void PrintVal(int x) 
        => Console.WriteLine(x);
}

public delegate int Transformer(int x);

public static class JustWrapperOfPluginMethods
{
    public static void Transform(
        int[] values,
        Transformer t)
    {
        for (int i = 0; i < values.Length; i++)
            values[i] = t(values[i]);
    }
}

public class WrapperForAnonymous
{
    private readonly Action _anonymousFunc;

    public WrapperForAnonymous(Action anonymousFunc)
    {
        _anonymousFunc = anonymousFunc;
    }

    public void TriggerAnonymousFunc()
    {
        _anonymousFunc.Invoke();
    }

    public void TriggerParameterAnonymousFunc(
        Func<int, int> DontKnowWhatThisDoYet,
        int value)
    {
        Console.WriteLine(DontKnowWhatThisDoYet(value));
    }
}