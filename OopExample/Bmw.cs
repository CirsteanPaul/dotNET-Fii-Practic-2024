namespace Oop;

public class Bmw : Car
{
    private const string BmwName = "Bmw"; // we can make this const 
    private const int BmwFuelCapacity = 60;
    private const int BmwFuelConsumption = 14;
    private static int _bmwId = 1; // this will be static because each instance created will increment it

    private static readonly SpeedsOnCondition OnCondition = new() 
        {
            OnRainy = 50,
            OnSnowy = 30,
            OnSunny = 80
        };
    // static readonly: we need static because this attribute is per class not per instance
    // readonly: This attribute is const but we initialize an object (so we need runtime constant)
    public Bmw() : base(_bmwId, BmwName, BmwFuelCapacity, BmwFuelConsumption, OnCondition)
    {
        _bmwId++;
    }
}