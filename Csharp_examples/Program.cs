// See https://aka.ms/new-console-template for more information

using Csharp_examples;

var input = "    ";
Console.WriteLine(string.IsNullOrWhiteSpace(input));
Console.WriteLine($"{input.Length}, {input.Count()}");
input = "  Fii practic";
Console.WriteLine("{0} 2024", input);

input = input.Trim();
Console.WriteLine(input.ToUpper());


int CalculateSum(int x, int y)
{
    return x + y;
}

var sum = CalculateSum(10, 15);
Console.WriteLine(CalculateSum(10, 15));

var foo = new Foo(10);
Console.WriteLine(foo.Id);
Console.WriteLine(foo.GetName());
Console.WriteLine(foo.Name);
Console.WriteLine(foo.GetSecret());
