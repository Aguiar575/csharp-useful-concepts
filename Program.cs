// See https://aka.ms/new-console-template for more information
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
if(stock is Asset)
    Console.WriteLine("Downcastig");

Asset assetDowncast = stock;

//upcast
if(assetDowncast is Stock)
    Console.WriteLine("Upcasting");

Stock stockUpcast = (Stock)assetDowncast;

Console.WriteLine("-------- generics --------");
var stringStack = new Stack<string>();
stringStack.Push("someWord");
stringStack.Push("MoreWord");

while(stringStack.HasNext)
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