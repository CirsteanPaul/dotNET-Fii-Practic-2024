namespace Polymorphism;

public class AClass : BaseClass // We inherit from BaseClass. So for your class to be valid we need to implement baseclass's methods
{
    public override string GetName() // We need an override because the methods from a abstract class may have implementations
    {
        return "Fii practic";
    }

    public override int GetId()
    {
        return 2024;
    }
}