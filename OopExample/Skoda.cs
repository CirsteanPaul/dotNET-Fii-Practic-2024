namespace Oop;

public class Skoda : Car
{
    private const string SkodaName = "Skoda";
    private const int SkodaFuelCapacity = 60;
    private const int SkodaFuelConsumption = 6;
    private static int _skodaId = 1;

    private static readonly SpeedsOnCondition OnCondition = new()
    {
        OnRainy = 60,
        OnSnowy = 40,
        OnSunny = 130
    };
    
    public Skoda() : base(_skodaId, SkodaName, SkodaFuelCapacity, SkodaFuelConsumption, OnCondition)
    {
        _skodaId++;
    }
}