using System;
using System.Collections.Generic;

namespace CarCompositionExample
{
    // Interface for the car parts
    public interface ICarPart
    {
        string GetDescription();
    }

    // Main Car Class for this  Project 
    public class Car
    {
        public string Model { get; set; }
        public Engine Engine { get; set; }
        public List<Seat> Seats { get; set; }
        public FuelTank FuelTank { get; set; }
        public List<Wheel> Wheels { get; set; }
        public Drivetrain Drivetrain { get; set; }

        // Constructor
        public Car(string model, Engine engine, List<Seat> seats, FuelTank fuelTank, List<Wheel> wheels, Drivetrain drivetrain)
        {
            Model = model;
            Engine = engine;
            Seats = seats;
            FuelTank = fuelTank;
            Wheels = wheels;
            Drivetrain = drivetrain;
        }

        // Method to display car details
        public void DisplayCarDetails()
        {
            Console.WriteLine($"Car Model: {Model}");
            Console.WriteLine($"- Engine: {Engine.GetDescription()}");
            Console.WriteLine($"- Fuel Tank: {FuelTank.GetDescription()}");
            Console.WriteLine($"- Drivetrain: {Drivetrain.GetDescription()}");
            Console.WriteLine($"- Seats: {Seats.Count} seats ({Seats[0].Material})");
            Console.WriteLine("- Wheels:");
            foreach (var wheel in Wheels)
            {
                Console.WriteLine($"  - {wheel.GetDescription()}");
            }
        }
    }

    // Engine Class
    public class Engine : ICarPart
    {
        public string Type { get; set; }
        public int Horsepower { get; set; }

        public Engine(string type, int horsepower)
        {
            Type = type;
            Horsepower = horsepower;
        }

        public string GetDescription()
        {
            return $"{Type}, {Horsepower} HP";
        }
    }

    // Seat Class
    public class Seat : ICarPart
    {
        public bool IsOccupied { get; set; }
        public string Material { get; set; }

        public Seat(string material)
        {
            IsOccupied = false;
            Material = material;
        }

        public string GetDescription()
        {
            return $"{Material} seat, Occupied: {IsOccupied}";
        }
    }

    // Fuel Tank Class
    public class FuelTank : ICarPart
    {
        public double Capacity { get; set; }
        public double CurrentLevel { get; set; }

        public FuelTank(double capacity)
        {
            Capacity = capacity;
            CurrentLevel = 0;
        }

        public void Refill(double amount)
        {
            CurrentLevel = Math.Min(CurrentLevel + amount, Capacity);
        }

        public string GetDescription()
        {
            return $"{CurrentLevel}/{Capacity} liters";
        }
    }

    // Drivetrain Class
    public class Drivetrain : ICarPart
    {
        public string Type { get; set; } // Example: "RWD", "AWD", "FWD"

        public Drivetrain(string type)
        {
            Type = type;
        }

        public string GetDescription()
        {
            return Type;
        }
    }

    // Base Wheel Class
    public class Wheel : ICarPart
    {
        public string Type { get; set; }

        public Wheel(string type)
        {
            Type = type;
        }

        public virtual string GetDescription()
        {
            return $"{Type} wheel";
        }
    }

    // Winter Wheel Class
    public class WinterWheel : Wheel
    {
        public WinterWheel() : base("Winter") { }
    }

    // Summer Wheel Class
    public class SummerWheel : Wheel
    {
        public SummerWheel() : base("Summer") { }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // Create a BMW M5 with Winter Wheels and AWD
            var bmwM5 = new Car(
                model: "BMW M5",
                engine: new Engine("V8 Twin Turbo", 600),
                seats: new List<Seat>
                {
                    new Seat("Leather"),
                    new Seat("Leather"),
                    new Seat("Leather"),
                    new Seat("Leather")
                },
                fuelTank: new FuelTank(68), // 68 liters
                wheels: new List<Wheel>
                {
                    new WinterWheel(),
                    new WinterWheel(),
                    new WinterWheel(),
                    new WinterWheel()
                },
                drivetrain: new Drivetrain("AWD") // All-Wheel Drive
            );

            // I Have added Refill fuel
            bmwM5.FuelTank.Refill(50); // 50 liters of fuel

            // Display for the car details
            bmwM5.DisplayCarDetails();
        }
    }
}
