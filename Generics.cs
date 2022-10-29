//Covariance and Contravariance
public interface IPoppable<out T>
{
    T Pop();
}

public interface IPushable<in T>
{
    void Push(T obj);
}

public class Stack<T> : IPoppable<T>, IPushable<T>
{
    int position;
    public T this[int index] { get { return data[index]; } }
    public bool HasNext { get { return position != 0; } }
    T[] data = new T[100];
    public void Push(T obj) => data[position++] = obj;
    public T Pop() => data[--position];
}

public class ClassWithGenericMethod
{
    public static void Swap<T>(ref T a, ref T b)
    {
        T temp = a;
        a = b;
        b = a;
    }
}

public class Animal
{
    public Animal(string name)
    {
        Name = name;
    }

    public string Name { get; set; }

}

public class Fox : Animal
{
    public Fox(string name) : base(name) { }

    public void DoABarrelRoll() { }
}