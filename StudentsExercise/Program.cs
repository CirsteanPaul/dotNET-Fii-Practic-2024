// See https://aka.ms/new-console-template for more information
using StudentsExercise;

Console.WriteLine("Choose from which file to read: ");
var input = Console.ReadLine();

IList<Result> results;
switch (input)
{
    case "input1.txt" :
        IReader reader1 = new Reader1();
        results = reader1.Read(input).ToList();
        break;
    case "input2.txt" :
        IReader reader2 = new Reader2();
        results = reader2.Read(input).ToList();
        break;
    default: 
        Console.WriteLine("Input file invalid");
        return;
}

results = results.OrderBy(x => x.Age).ToList();
Console.WriteLine($"Youngest: {results.First().Name}");
Console.WriteLine($"Oldest: {results.Last().Name}");
