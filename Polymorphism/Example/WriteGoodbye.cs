namespace Polymorphism.Example;

public class WriteGoodbye : IWrite
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