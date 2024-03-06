// See https://aka.ms/new-console-template for more information

using Dumpify;

IList<int> list = new List<int>()
{
    1,2,3,4,5
};

list.Dump();
var variable = list[2];
list.Add(7);

list.Dump();

IEnumerable<int> enumerable = new List<int>()
{
    1,2,3,4,5
};

// Main difference is when we call Add in a IList the operation is executed
// In IEnumerable a template on which we work on until we call a materilize function such as:
// ToList(), Any(), Count() ...
// Still the problem is that if we don't know this factor and work on the template multiple times each call
// will create a new space of memory thus losing performance by a lot.
var result = enumerable.Append(6);

enumerable.Dump();
result.Dump();

var x = result.Where(x => x > 3);
// var var2 = x[2];
x.Dump();
x.ToList().Dump();
x.ToList().Dump();