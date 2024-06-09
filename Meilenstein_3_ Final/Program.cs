namespace Meilenstein_3
{
    interface IDriveable
    {
        void Drive();
        void Refuel();
    }
    interface IMaintainable
    {
        void PerformMaintenance();
        void CheckOil();
    }
    interface ILoadable
    {
        int LoadCapacity { get; set; }
        void LoadCargo(int weight);
    }

    public abstract class Vehicle : IDriveable, IMaintainable
    {
        public string Marke { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }

        public Vehicle(string amarke, string amodel, int ayear)
        {
            Marke = amarke;
            Model = amodel;
            Year = ayear;
        }
        public abstract void DisplayInfo()
        {
            Console.WriteLine($"Das Fahrzeug hat die Daten: \n Hersteller: {Marke}, Modell: {Model}, Baujahr: {Year}");
        }

        public void Start()
        {
            Console.WriteLine("Das Fahrzeug startet.");
        }
        public abstract void Drive();
        public abstract void Refuel();
        public abstract void PerformMaintenance();
        public abstract void CheckOil();
    }
    public class Car :Vehicle
    {
        public int NumberOfDoors { get; set; }
        public Car(string amarke, string amodel, int ayear, int anumberOfDoors) : base(amarke, amodel, ayear)
        {
            NumberOfDoors = anumberOfDoors;
        }
        public void Drive() 
        {
            Console.WriteLine($"...fährt.");
        }
        public void Refuel()
        {
            Console.WriteLine($"...wird betankt.");
        }
        public void PerformMaintenance()
        {
            Console.WriteLine($"...wird gewartet.");
        }
        public void CheckOil()
        {
            Console.WriteLine($"Der Ölstand...wird geprüft.");
        ]}
        public void DisplayInfo()
        {
            Console.WriteLine($"Das Fahrzeug hat die Daten: \n Hersteller: {Marke}, Modell: {Model}, Baujahr: {Year}");
        }
    }
    public class Truck :Vehicle, ILoadable
    {
        public int LoadCapacity { get; set; }
        public void LoadCargo(int weight);
        public Truck(string amarke, string amodel, int ayear, int aloadCapacity) : base(amarke, amodel, ayear)
        {
            LoadCapacity = aloadCapacity;
        }
        public override void Drive()
        {
            Console.WriteLine($"...fährt.");
        }
        public override void Refuel()
        {
            Console.WriteLine($"...wird betankt.");
        }
        public override void PerformMaintenance()
        {
            Console.WriteLine($"...wird gewartet.");
        }
        public override void CheckOil()
        {
            Console.WriteLine($"Der Ölstand...wird geprüft.");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Das Fahrzeug hat die Daten: \n Hersteller: {Marke}, Modell: {Model}, Baujahr: {Year}");
        }
    }

    public class Fleet :IEnumerable
    {
        //public void AddVehicle(Vehicle vehicle);
        /*public IEnumerator GetEnumerator()
        {
            return new
        }*/ 
        //MoveNext, Reset, Current object noch dazu
    }

    class Program
    {
        static void InspectVehicle( … )
        {
            // vehicle.DisplayInfo();
            //vehicle.Start();
            // Hier soll ein Truck beladen werden.
        }
        static void Main(string[] args)
        {
            //Car car = new Car("Toyota", "Corolla", 2020, 4);
            //Truck truck = new Truck("MAN", "TGX", 2018, 12000);
            //Fleet fleet = new Fleet();
            //fleet.AddVehicle(car);
            //fleet.AddVehicle(truck);
            // Hier soll die Methode InspectVehicle(...)
            // für alle Fahrzeuge ausgeführt werden.
        }
    }
}
