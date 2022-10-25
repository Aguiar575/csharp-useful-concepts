// See https://aka.ms/new-console-template for more information
Console.WriteLine("-------- params modifier --------");
Console.WriteLine(ParamsModifier.SumBunchOfInts(1, 2, 3, 4));

Console.WriteLine("-------- null operators --------");
NullOperators.Coalescing();
NullOperators.CoalescingAssignmet();
NullOperators.CoalescingElvis();

Console.WriteLine("-------- switch with pattern --------");
Switch.SwitchPatternMatching();