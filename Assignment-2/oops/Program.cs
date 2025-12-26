using System;

namespace TransportManagement
{
    // Abstract Class A
    public abstract class Vehicle
    {
        public string Model { get; set; }
        public string Manufacturer { get; }
        public string VehicleType; // Field

        public Vehicle(string manufacturer)
        {
            Manufacturer = manufacturer;
        }

        public abstract void Start(); // Abstract Method
    }

    // Interface C
    public interface IService
    {
        void Repair();
        void Fuel(string type);
    }

    // Class B inherits from Vehicle
    public class Car : Vehicle, IService
    {
        public int Speed { get; set; }

        public Car(string manufacturer, string model) : base(manufacturer)
        {
            Model = model;
            VehicleType = "Car";
        }

        public override void Start()
        {
            Console.WriteLine($"{Manufacturer} {Model} Car is starting...");
        }

        public void Repair()
        {
            Console.WriteLine($"{Manufacturer} {Model} Car is under repair.");
        }

        public void Fuel(string type)
        {
            Console.WriteLine($"{Manufacturer} {Model} Car refueled with {type}.");
        }

        public void Drive()
        {
            Console.WriteLine($"{Manufacturer} {Model} Car is driving at {Speed} km/h.");
        }
    }

    // Class D inherits from Car
    public class ElectricCar : Car
    {
        public static int ChargingStations = 10; // static field

        public ElectricCar(string manufacturer, string model) : base(manufacturer, model)
        {
            VehicleType = "ElectricCar";
        }

        // Overriding Start method
        public override void Start()
        {
            Console.WriteLine($"{Manufacturer} {Model} Electric Car is powering on silently...");
        }

        // Overriding Drive method
        public new void Drive()
        {
            Console.WriteLine($"{Manufacturer} {Model} Electric Car is driving with eco mode.");
        }

        public void Charge()
        {
            Console.WriteLine($"{Manufacturer} {Model} is charging at station.");
        }
    }

    // Program Entry
    class Program
    {
        static void Main(string[] args)
        {
            Car myCar = new Car("Toyota", "Corolla");
            myCar.Start();
            myCar.Fuel("Petrol");
            myCar.Repair();
            myCar.Speed = 80;
            myCar.Drive();

            Console.WriteLine();

            ElectricCar tesla = new ElectricCar("Tesla", "Model 3");
            tesla.Start();
            tesla.Fuel("Electric"); // from interface
            tesla.Repair();         // from interface
            tesla.Drive();
            tesla.Charge();

            Console.WriteLine($"Available charging stations: {ElectricCar.ChargingStations}");
        }
    }
}

