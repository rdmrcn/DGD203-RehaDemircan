using System;
using System.Collections.Generic;

namespace CarCompositionExample
{
    // Main Car Class
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public List<Seat> Seats { get; set; }
        public FuelTank FuelTank { get; set; }
        public List<Wheel> Wheels { get; set; }

        // Constructor to initialize all components
        public Car(string model, Engine engine, List<Seat> seats, FuelTank fuelTank, List<Wheel> wheels)
        {
            Model = model;
            Engine = engine;
            Seats = seats;
            FuelTank = fuelTank;
            Wheels = wheels;
        }

        // Method to display car details
        public void DisplayCarDetails()
        {
            Console.WriteLine($"Car Model: {Model}");
            Console.WriteLine($"- Engine Type: {Engine.Type}, Horsepower: {Engine.Horsepower}");
            Console.WriteLine($"- Fuel Tank Capacity: {FuelTank.Capacity} liters, Current Level: {FuelTank.CurrentLevel} liters");
            Console.WriteLine($"- Number of Seats: {Seats.Count}, Material: {Seats[0].Material}");
            Console.WriteLine($"- Wheel Type: {Wheels[0].Type}");
        }
    }

    // Engine Class
    public class Engine
    {
        public string Type { get; set; } // Example: "V8", "Electric"
        public int Horsepower { get; set; }

        public Engine(string type, int horsepower)
        {
            Type = type;
            Horsepower = horsepower;
        }
    }

    // Seat Class
    public class Seat
    {
        public bool IsOccupied { get; set; }
        public string Material { get; set; } // Example: "Leather", "Fabric"

        public Seat(string material)
        {
            IsOccupied = false;
            Material = material;
        }
    }

    // Fuel Tank Class
    public class FuelTank
    {
        public double Capacity { get; set; } // in liters
        public double CurrentLevel { get; set; }

        public FuelTank(double capacity)
        {
            Capacity = capacity;
            CurrentLevel = 0; // Empty initially
        }

        public void Refill(double amount)
        {
            CurrentLevel = Math.Min(CurrentLevel + amount, Capacity);
        }
    }

    // Wheel Class
    public class Wheel
    {
        public string Type { get; set; } // Example: "Summer", "Winter"

        public Wheel(string type)
        {
            Type = type;
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Create a BMW M5 Car object with winter wheels
            var bmwM5 = new Car(
                model: "BMW M5",
                engine: new Engine("V8 Twin Turbo", 600), // 600 horsepower
                seats: new List<Seat>
                {
                    new Seat("Leather"),
                    new Seat("Leather"),
                    new Seat("Leather"),
                    new Seat("Leather")
                },
                fuelTank: new FuelTank(68), // 68 liters capacity
                wheels: new List<Wheel>
                {
                    new Wheel("Winter"),
                    new Wheel("Winter"),
                    new Wheel("Winter"),
                    new Wheel("Winter")
                }
            );

            // Refill the fuel tank
            bmwM5.FuelTank.Refill(50); // Add 50 liters of fuel

            // Display car details
            bmwM5.DisplayCarDetails();
        }
    }
}
