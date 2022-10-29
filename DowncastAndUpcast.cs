//upcasting and downcasting performs a reference conversion;
//therefore, new reference is created that points to the same object;
public class Asset
{
    public Asset(string name)
    {
        Name = name;
    }
    public string Name;
    public virtual decimal Liability => 0;
}

public class Stock : Asset
{
    //subclass must redefine any constructors that it wants to expose;
    public Stock(string name) : base(name)
    {
    }

    //virtual can be or not be overriden by subclasses;
    //we can seal the override to nex class cant override this behaviour;
    public sealed override decimal Liability => 12;
    public long SharesOwned { get; set; }
}