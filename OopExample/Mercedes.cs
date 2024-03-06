namespace Oop;

public class Mercedes : Car
{
    private const string MercedesName = "Mercedes";
    private const int MercedesFuelCapacity = 80;
    private const int MercedesFuelConsumption = 18;
    private static int _mercedesId = 1;

    private static readonly SpeedsOnCondition OnCondition = new()
    {
        OnRainy = 40,
        OnSnowy = 40,
        OnSunny = 70
    };
    
    public Mercedes() : base(_mercedesId, MercedesName, MercedesFuelCapacity, MercedesFuelConsumption, OnCondition)
    {
        _mercedesId++;
    }
}