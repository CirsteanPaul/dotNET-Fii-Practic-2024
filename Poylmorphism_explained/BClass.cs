namespace Polymorphism;

public class BClass : IBaseClass // We inherit from IBaseClass. So for your class to be valid we need to implement interface's methods
{
    public string GetName() // We can see we don't need an override because an interface has pure methods
    {
        return "Fii practic";
    }

    public int GetId()
    {
        return 2024;
    }
}