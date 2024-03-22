// See https://aka.ms/new-console-template for more information

using System.Text;
using Constants;

var list = new List<Abbreviation>
{
    new()
    {
        FullText = "pentru",
        Abbr = "pt"
    },
    new()
    {
        FullText = "doamna",
        Abbr = "dna"
    },
    new()
    {
        FullText = "domnul",
        Abbr = "dl"
    }
};

string input = "Am fost la dl Matei pt că m-a invitat cu o zi înainte.";
StringBuilder result = new StringBuilder();
foreach (var word in input.Split(" "))
{
    var abbr = list.FirstOrDefault(x => x.Abbr == word);
    if (abbr is null)
    {
        result.Append(word);
    }
    else
    {
        result.Append(abbr.FullText);
    }
    result.Append(' ');
}

Console.WriteLine(result.Remove(result.Length - 1, 1).ToString());
