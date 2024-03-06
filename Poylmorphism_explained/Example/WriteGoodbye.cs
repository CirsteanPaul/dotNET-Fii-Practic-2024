namespace Polymorphism.Example;

public class WriteGoodbye : IWrite // This class inherits the IWrite interface so needs the method Write
{
    public void Write()
    {
        Console.WriteLine("Goodbye");
    }

    public void WriteNotSeen()
    {
        Console.WriteLine("Write not seen");
    }
}