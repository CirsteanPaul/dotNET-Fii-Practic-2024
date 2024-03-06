// See https://aka.ms/new-console-template for more information

var list = new List<int>();
list.Add(10);
list.Add(20);
foreach(var item in list) {
    Console.WriteLine(item);
}

Console.WriteLine($"Size of list {list.Count}");
Console.WriteLine($"List contains 10: {list.Contains(10)}");
Console.WriteLine(list.Max());
Console.WriteLine($"Does element 15 exists? {list.FirstOrDefault(x => x == 15)}");
// Console.WriteLine(list.First(x => x == 15));

var filteredEnumerable = list.Where(x => x > 10);
var filteredList = filteredEnumerable.ToList();
foreach (var item in filteredEnumerable)
{
    Console.WriteLine(item);
}

foreach (var item in filteredList.Select(x => x + 10))
{
    Console.WriteLine(item);
}


IEnumerable<int> l = new List<int>();
IList<int> ll = new List<int>();
ICollection<int> lll = new List<int>();
// ....

