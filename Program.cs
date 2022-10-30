// See https://aka.ms/new-console-template for more information
using Unsafe;

Console.WriteLine("-------- params modifier --------");
Console.WriteLine(ParamsModifier.SumBunchOfInts(1, 2, 3, 4));

Console.WriteLine("-------- null operators --------");
NullOperators.Coalescing();
NullOperators.CoalescingAssignmet();
NullOperators.CoalescingElvis();

Console.WriteLine("-------- switch with pattern --------");
Switch.SwitchPatternMatching();

Console.WriteLine("-------- downcast and upcast --------");
var stock = new Stock("None");

//Downcast
if (stock is Asset)
    Console.WriteLine("Downcastig");

Asset assetDowncast = stock;

//upcast
if (assetDowncast is Stock)
    Console.WriteLine("Upcasting");

Stock stockUpcast = (Stock)assetDowncast;

Console.WriteLine("-------- generics --------");
var stringStack = new Stack<string>();
stringStack.Push("someWord");
stringStack.Push("MoreWord");

while (stringStack.HasNext)
    Console.WriteLine(stringStack.Pop());

//Covariance
var foxes = new Stack<Fox>();
foxes.Push(new Fox("StarFox"));

IPoppable<Animal> animals = foxes;
Animal animal = animals.Pop();
Console.WriteLine(animal.Name);

//Contravariance
IPushable<Animal> moreAnimals = new Stack<Animal>();
IPushable<Fox> moreFoxes = moreAnimals;
moreFoxes.Push(new Fox("StarFox"));

Console.WriteLine("-------- delegates --------");
Transformer t = SomeOperations.Square;
Console.WriteLine(t(2));

int[] values = { 1, 2, 3, 4 };
JustWrapperOfPluginMethods.Transform(values, t);
foreach (int val in values)
    Console.WriteLine(val);

//Action is Always void
Action<int> action = SomeOperations.PrintVal;
action(23);

//Func returns value;
Func<int, int> func = SomeOperations.Square;
Console.WriteLine(func(12));

Action print = delegate
{
    Console.WriteLine("Anonymous call");
};

WrapperForAnonymous anon = new WrapperForAnonymous(print);
anon.TriggerAnonymousFunc();
anon.TriggerParameterAnonymousFunc(SomeOperations.Square, 2);

Console.WriteLine("-------- events --------");
Events.Stock stockEvents = new Events.Stock("THPW");
stockEvents.Price = 27.10M;

stockEvents.PriceChanged += Events.StockPrice.StockPriceChanged;
stockEvents.Price = 31.59M;

Console.WriteLine("-------- extension methods --------");
string captalizedword = "SomeWord";
if (captalizedword.IsCaptalized())
    Console.WriteLine("Captalized");

Console.WriteLine("-------- anonymous Types --------");
int age = 1;
var dude = new { Name = "Bob", Age = age };

//Anonymous tuples
(string, int) bob = ("Bob", 23);

Console.WriteLine("-------- unsafe blocks --------");
Test test = new Test();
unsafe {
    fixed(int* p = &test.X)
    {
        *p = 9;
    }
    Console.WriteLine(test.X);
}

//pointer-to-member
TestStruct testStruct = new TestStruct();
unsafe {
    TestStruct* p = &testStruct;
    p->X = 9;

    Console.WriteLine(testStruct.X);
}
