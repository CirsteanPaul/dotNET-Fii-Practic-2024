namespace Oop;

public class Circuit
{
    private int _circuitLength; // the length of the circuit should not be available outside of circuit context
    private WeatherCondition _weatherCondition = WeatherCondition.Rainy; // same for weather condition
    private readonly List<Car> _cars = new();
    private readonly List<Result> _results = new();
    public void SetLength(int length)
    {
        _circuitLength = length; // basic setter
    }

    public void SetWeather(WeatherCondition weatherCondition)
    {
        _weatherCondition = weatherCondition;
    }

    public void AddCar(Car car)
    {
        _cars.Add(car);
    }

    public void Race()
    {
        foreach (var car in _cars)
        {
            var kilometersPossible = (double)car.FuelCapacity / car.FuelConsumption * 100; 
            // we find out what is the maximum length a car can make with it's fuel.
            if (kilometersPossible < _circuitLength)
            {
                _results.Add(new Result
                {
                    Id = car.Id,
                    Name = car.Name,
                    TimeFinished = -1 // -1 means the car didn't finish the race
                });
                
                continue;
            }

            var speed = GetCurrentSpeed(car);
            var time = (double)_circuitLength / speed;
            _results.Add(new Result
            {
                Id = car.Id,
                Name = car.Name,
                TimeFinished = time
            });
        }
    }

    public void ShowFinalRanks()
    {
        var resultsInOrder = _results.Where(x => (int)x.TimeFinished != -1)
            .OrderBy(x => x.TimeFinished);
        // filter the car which finished and sort by the TimeFinished.
        foreach (var result in resultsInOrder)
        {
            Console.WriteLine($"{result.Id}  {result.Name}  {result.TimeFinished} h");
        }
    }

    public void ShowWhoDidNotFinish()
    {
        var resultsInOrder = _results.Where(x => (int)x.TimeFinished == -1);
        // filter the cars which didn't finish
        foreach (var result in resultsInOrder)
        {
            Console.WriteLine($"{result.Id}  {result.Name}  {result.TimeFinished}");
        }
    }

    private int GetCurrentSpeed(Car car)
    {   // this function selects the specific speed by the weather condition
        return _weatherCondition switch
        {
            WeatherCondition.Rainy => car.Speeds.OnRainy,
            WeatherCondition.Snowy => car.Speeds.OnSnowy,
            WeatherCondition.Sunny => car.Speeds.OnSunny,
            _ => car.Speeds.OnRainy
        };
    }
}