// See https://aka.ms/new-console-template for more information

using Csharp_examples;

var input = "    "; // compiler understands which type the variable has.
                    // This keyword is var(widely-used) In this case input is a string
Console.WriteLine(string.IsNullOrWhiteSpace(input)); // console.writeline is how c# writes the output in console.
                            // The function IsNullOrWhiteSpace returns a boolean value: true if the string is empty or null 
                            // false otherwise
Console.WriteLine($"{input.Length}, {input.Count()}"); // length and count does the same thing(returns the length of the string)
                                        // If we add a $ before a string we can add in {} a variable. In this case we concatenate the values
input = "  Fii practic";
Console.WriteLine("{0} 2024", input); // This is another type of concatenation in which we specify the position of
                                    // of variable.

input = input.Trim(); // eliminates the whitespaces from the beginning and the end of the string.
Console.WriteLine(input.ToUpper()); 


int CalculateSum(int x, int y)
{
    return x + y;
}

var sum = CalculateSum(10, 15);
Console.WriteLine(CalculateSum(10, 15));

var foo = new Foo(10); // new creates a new object of type Foo(in this case)
Console.WriteLine(foo.Id);
Console.WriteLine(foo.GetName());
Console.WriteLine(foo.Name);
Console.WriteLine(foo.GetSecret());

var foo2 = new Foo2(5);
Console.WriteLine(foo2.Id);