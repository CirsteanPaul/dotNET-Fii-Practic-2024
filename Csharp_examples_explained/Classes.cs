namespace Csharp_examples;

public class Foo
{
    private readonly string secret = "Fii practic"; // private means we have access only in the context of the class
    // readonly is const (but at the runtime). https://www.geeksforgeeks.org/difference-between-readonly-and-const-keyword-in-c-sharp/
    public int Id { get; set; } // this is a way to create a property and default get method and set method
    public string Name { get; set; } = string.Empty; // = string.Empty we initialize the property with an empty string.
                                                    // string can be null.
    public string? MayBeNull { get; set; } // the ? means this variable may be null
    public int? Number { get; set; }
    public Foo(int id) // constructor
    {
        Id = id;
    }

    public string GetName()
    {
        if (MayBeNull is null) // in case of string. This approach works on primitives as well
        {
            // do something
        }

        if (Number.HasValue) // in case of primitive types(int, bool, double ...)
        {
            // do something
        }
        return Name;
    }

    public string GetSecret()
    {
        return secret;
    }
}

public class Foo2(int id) // this is called primary constructor and does the same thing as line 12. It's code-sugar
{
    public int Id { get; set; } = id; // We need to initialize the Id with the value from the constructor line 37.
}