Write the following classes in C#:

An abstract class Car that reflects some properties on a car (id, name, fuel capacity, fuel consumption, average speed on different conditions (Rain, Sunny, Snow)).

Derive from this class several types of Cars with different characteristics for fuel capacity, fuel consumption, name, id, speed in different weather conditions.

For weather conditions, create an enum object.

Create a class circuit that will test how different cars behave in a race depending on the length of the circuit and the race weather condition. The circuit will use polymorphism to simulate the race conditions (e.g. will have an array of objects of type
Car and an array of results.).

Use the following
main snippet to show how this ensemble works:

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
