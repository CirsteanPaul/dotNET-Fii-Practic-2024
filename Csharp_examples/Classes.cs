namespace Csharp_examples;

public class Foo
{
    private readonly string secret = "Fii practic";
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? MayBeNull { get; set; }
    public Foo(int id)
    {
        Id = id;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetSecret()
    {
        return secret;
    }
}

public class Foo2(int id)
{
    public int Id { get; set; } = id;
}