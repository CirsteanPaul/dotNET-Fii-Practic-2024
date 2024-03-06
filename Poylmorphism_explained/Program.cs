// See https://aka.ms/new-console-template for more information

using Polymorphism;
using Polymorphism.Example;

var aClass = new AClass();
Console.WriteLine($"{aClass.GetName()} {aClass.GetId()}");

var bClass = new BClass();
Console.WriteLine($"{bClass.GetName()} {bClass.GetId()}");

// var y = new IBaseClass();
// var x = new BaseClass(); // This lines of code will throw a compilation error because
// we cannot create an instance of an abstract class or interface

IWrite write = new WriteGoodbye(); // write is of type WriteGoodbye but we limit it's access only to IWrite
IWrite write2 = new WriteHello(); 
write.Write(); // WriteGoodbye contains WriteNotSeen method which is uncallable in this context because we use the interface
write2.Write();

var cClass = new CClass();
try
{
    cClass.GetName(); // this function will throw an exception because it's not implemented (check CClass)
    // We will try to call this method and if it throws we will catch the exception
}
catch (Exception e) // we catch the exception and write the message. Play around with it
{
    Console.WriteLine(e.Message);
}
