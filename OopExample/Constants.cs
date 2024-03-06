namespace Oop;

public enum WeatherCondition
{
    Rainy,
    Sunny,
    Snowy
}

public class SpeedsOnCondition
{
    public int OnSunny { get; init; } // we want only to have getters and initialize the value so no setter is needed
    public int OnSnowy { get; init; }
    public int OnRainy { get; init; }
}

public class Result
{
    public int Id { get; init; }
    public string Name { get; init; }
    public double TimeFinished { get; init;  }
}