namespace Unsafe;

public class UnsafeClass
{
    unsafe void BlueFilter(int[,] bitmap)
    {
        int length = bitmap.Length;
        fixed(int* b = bitmap)
        {
            int* p = b;
            for(int i = 0; i < length; i++)
                *p++ &= 0xFF;
        }
    }
}

class Test { public int X; }
struct TestStruct { public int X; }