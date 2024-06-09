using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;

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

        public void Start()
        {
            Console.WriteLine("Das Fahrzeug startet.\n");
        }
        public abstract void DisplayInfo();

        public abstract void Drive();
        public abstract void Refuel();
        public abstract void PerformMaintenance();
        public abstract void CheckOil();
    }

    public class Car : Vehicle
    {
        public int NumberOfDoors { get; set; }
        public Car(string amarke, string amodel, int ayear, int anumberOfDoors) : base(amarke, amodel, ayear)
        {
            NumberOfDoors = anumberOfDoors;
        }

        public override void Drive()
        {
            Console.WriteLine($"Das Auto {Marke} {Model} fährt.\n");
        }
        public override void Refuel()
        {
            Console.WriteLine($"Das Auto {Marke} {Model} wird betankt.\n");
        }
        public override void PerformMaintenance()
        {
            Console.WriteLine($"Das Auto {Marke} {Model} wird gewartet.\n");
        }
        public override void CheckOil()
        {
            Console.WriteLine($"Der Ölstand vom Auto {Marke} {Model} wird geprüft.\n");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"Auto-Marke: {Marke}, Modell: {Model}, Baujahr: {Year}\n");
        }
    }

    public class Truck : Vehicle, ILoadable
    {
        public int LoadCapacity { get; set; }

        public Truck(string amarke, string amodel, int ayear, int aloadCapacity) : base(amarke, amodel, ayear)
        {
            LoadCapacity = aloadCapacity;
        }
        public override void Drive()
        {
            Console.WriteLine($"Der LKW {Marke} {Model} fährt.\n");
        }
        public override void Refuel()
        {
            Console.WriteLine($"Der LKW {Marke} {Model} wird betankt.\n");
        }
        public override void PerformMaintenance()
        {
            Console.WriteLine($"Der LKW {Marke} {Model} wird gewartet.\n");
        }
        public override void CheckOil()
        {
            Console.WriteLine($"Der Ölstand des LKWs {Marke} {Model} wird geprüft.\n");
        }
        public override void DisplayInfo()
        {
            Console.WriteLine($"LKW-Marke: {Marke}, Modell: {Model}, Baujahr: {Year}\n");
        }

        public void LoadCargo(int weight)
        {
            if (weight > LoadCapacity)
            {
                throw new InvalidOperationException("Die Ladung überschreitet die maximale Ladekapazität.\n");
            }
            Console.WriteLine($"Ladung von {weight} kg wird geladen.\n");
        }
    }

    public class FieldNode
    {
        public Vehicle Vehicle { get; set; }
        public FieldNode Next { get; set; }

        public FieldNode(Vehicle vehicle)
        {
            Vehicle = vehicle;
            Next = null;
        }
    }

    public class Fleet : IEnumerable
    {
        private FieldNode head;

        public Fleet()
        {
            head = null;
        }

        public void AddVehicle(Vehicle vehicle)
        {
            FieldNode newNode = new FieldNode(vehicle);
            if (head == null)
            {
                head = newNode;
            }
            else
            {
                FieldNode current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new FleetEnumerator(head);
        }

        private class FleetEnumerator : IEnumerator
        {
            private FieldNode current;
            private FieldNode head;

            public FleetEnumerator(FieldNode head)
            {
                this.head = head;
                current = null;
            }

            public bool MoveNext()
            {
                if (current == null)
                {
                    current = head;
                }
                else
                {
                    current = current.Next;
                }
                if (current == null)
                {
                    return false;
                }
                else { return true; }
            }

            public void Reset()
            {
                current = null;
            }

            public object Current
            {
                get
                {
                    if (current == null)
                    {
                        throw new InvalidOperationException("Ein Fehler wurde erfasst.");
                    }
                    return current.Vehicle;
                }
            }
        }
    }

    public class Program
    {
        public static void InspectVehicle(Vehicle vehicle)
        {
            Console.WriteLine("---- Verwaltung eines Fuhrparks ----");

            vehicle.DisplayInfo();
            vehicle.Start();
            vehicle.Drive();
            vehicle.Refuel();
            vehicle.PerformMaintenance();
            vehicle.CheckOil();

            if (vehicle is Car car)
            {
                Console.WriteLine($"Anzahl der Türen: {car.NumberOfDoors}\n");
            }
            else if (vehicle is Truck truck)
            {
                Console.WriteLine($"Ladekapazität: {truck.LoadCapacity} kg\n");
                try
                {
                    truck.LoadCargo(5000);  //passt, aber vlt haben wir bessere Ideen nach der Vorlesung mit Ex.
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Fehler beim Laden des LKW: {ex.Message}\n");
                }
            }
        }

        public static void Main(string[] args)
        {
            Car car = new Car("Toyota", "Corolla", 2020, 4);
            Truck truck = new Truck("MAN", "TGX", 2018, 12000);

            Fleet fleet = new Fleet();
            fleet.AddVehicle(car);
            fleet.AddVehicle(truck);

            foreach (Vehicle vehicle in fleet)
            {
                InspectVehicle(vehicle);
            }
        }
    }
}
