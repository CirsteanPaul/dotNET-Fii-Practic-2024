// See https://aka.ms/new-console-template for more information

using Oop;

Circuit circuit = new Circuit();
circuit.SetLength(500);
circuit.SetWeather(WeatherCondition.Sunny);
circuit.AddCar(new Bmw());
circuit.AddCar(new Bmw());
circuit.AddCar(new Mercedes());
circuit.AddCar(new Skoda());
circuit.Race();
circuit.ShowFinalRanks(); // it will print the time each car needed to finish the circuit sorted from the fastest car to the slowest.
circuit.ShowWhoDidNotFinish(); // it is possible that some cars don't have enough fuel to finish the circuit.
