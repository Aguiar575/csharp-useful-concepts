//struct is similar to a class but...
//struct is a value type, whereas a class is a reference type
//this data type resides in stack
//IF A CLASS HAVE A STRUCT IN ITS COMPOSITION 
//THE STRUCT WILL BE PUT IN HEAP INDIRECTLY
public struct SomeStrcut
{
    int x, y;
}

public struct AnotherStruct 
{
    int x = 1;
    int y;
    public AnotherStruct() => y = 1;
}