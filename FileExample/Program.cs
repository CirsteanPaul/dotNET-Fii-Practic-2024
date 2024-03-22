// See https://aka.ms/new-console-template for more information

using System.Text;

var allLines = File.ReadLines("../../../in.txt", Encoding.UTF8);

var sum = 0;
foreach (var line in allLines)
{
    if (int.TryParse(line, out var number))
    {
        sum += number;
    }

    int x = number;
}

Console.WriteLine(sum);
