namespace Polymorphism.Example;

public class WriteHello : IWrite // This class inherits the IWrite interface so needs the method Write
{
    public void Write()
    {
        Console.WriteLine("Hello");
    }
    
    public void WriteNotSeen() // This function will not be accessible if we use the class in context of IWrite interface
    {
        Console.WriteLine("Write not seen");
    }
}