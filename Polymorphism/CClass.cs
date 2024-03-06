namespace Polymorphism;

// public class CClass: BaseClass, BaseClass2
// {
//     
// }


public class CClass: BaseClass, IBaseClass2
{
    public override string GetName()
    {
        throw new NotImplementedException();
    }

    public override int GetId()
    {
        throw new NotImplementedException();
    }

    public string GetColor()
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