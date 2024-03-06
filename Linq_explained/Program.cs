// See https://aka.ms/new-console-template for more information

var list = new List<int>(); // Use dynamic lists. Equivalent of std::vector in c++
list.Add(10);
list.Add(20);
foreach(var item in list) { // foreach will iterate over all elements. "for" syntax is available too.
    Console.WriteLine(item);
}

Console.WriteLine($"Size of list {list.Count}");
Console.WriteLine($"List contains 10: {list.Contains(10)}");
Console.WriteLine(list.Max());
Console.WriteLine($"Does element 15 exists? {list.FirstOrDefault(x => x == 15)}"); 
// Get the first element which satisfies the condition in the function (x => x == 15)
// Console.WriteLine(list.First(x => x == 15)); This function will throw an error because it doesn't have the default value.

var filteredEnumerable = list.Where(x => x > 10); // This will filter the elements which satisfies the condition
var filteredList = filteredEnumerable.ToList(); // We transform the Enumerable in a List
foreach (var item in filteredEnumerable) // We can iterate enumerables exactly as lists
{
    Console.WriteLine(item);
}

foreach (var item in filteredList.Select(x => x + 10)) // Select(map) will iterate over all the elements in the list and will return a list
                                                       // with the new elements transformed in the function
{
    Console.WriteLine(item);
}


IEnumerable<int> l = new List<int>(); // Multiple interfaces for lists.
IList<int> ll = new List<int>();
ICollection<int> lll = new List<int>();
// More details: https://www.linkedin.com/pulse/what-difference-ienumerable-vs-ilist-icollection-kushal-developer/
// This link provides surface information about these interfaces.
// ....