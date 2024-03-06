namespace Polymorphism.Example;

public class WriteHello : IWrite
{
    public void Write()
    {
        Console.WriteLine("Hello");
    }
    
    public void WriteNotSeen()
    {
        Console.WriteLine("Write not seen");
    }
}