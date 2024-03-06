// See https://aka.ms/new-console-template for more information

using Polymorphism;
using Polymorphism.Example;

var aClass = new AClass();
Console.WriteLine($"{aClass.GetName()} {aClass.GetId()}");

var bClass = new BClass();
Console.WriteLine($"{bClass.GetName()} {bClass.GetId()}");

// var x = new BaseClass();
// var y = new IBaseClass();

IWrite write = new WriteGoodbye();
IWrite write2 = new WriteHello();
write.Write();
write2.Write();

var cClass = new CClass();
try
{
    cClass.GetName();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}
