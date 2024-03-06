namespace Oop;

public abstract class Car
{
    protected Car(int id, string name, int fuelCapacity, int fuelConsumption, SpeedsOnCondition speedsOnCondition)
    {
        Id = id;
        Name = name;
        FuelCapacity = fuelCapacity;
        FuelConsumption = fuelConsumption;
        Speeds = speedsOnCondition;
    }
    public int Id { get; } // we don't need setters. We should never change this variables after initilization
    public string Name { get; }
    public int FuelCapacity { get; }
    public int FuelConsumption { get; }
    public SpeedsOnCondition Speeds { get; }
}