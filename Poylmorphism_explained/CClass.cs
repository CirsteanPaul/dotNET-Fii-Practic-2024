namespace Polymorphism;

// public class CClass: BaseClass, BaseClass2 // C# will not accept multiple inheritance if the base class is not an interface
// {
//     
// }


public class CClass: BaseClass, IBaseClass2 // In this case we inherit the BaseClass and use the interface. This code is valid
{
    public override string GetName() // We can see the methods from abstract class needs an override
    {
        throw new NotImplementedException(); // we will throw an exception because the method is not implemented
    }

    public override int GetId()
    {
        throw new NotImplementedException();
    }

    public string GetColor() // This method is from an interface so override is not necessary
    {
        throw new NotImplementedException();
    }
}

public class CClass2: IBaseClass, IBaseClass2
{
    public string GetName()
    {
        throw new NotImplementedException();
    }

    public int GetId()
    {
        throw new NotImplementedException();
    }

    public string GetColor()
    {
        throw new NotImplementedException();
    }
}