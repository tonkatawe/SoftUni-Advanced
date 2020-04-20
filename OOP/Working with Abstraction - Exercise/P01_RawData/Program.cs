using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace P01_RawData
{
    class RawData
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int lines = int.Parse(Console.ReadLine());
            for (int i = 0; i < lines; i++)
            {
                var input = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                //make engine
                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                var currentEngine = new Engine(engineSpeed, enginePower);
                //make cargo
                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                var currentCargo = new Cargo(cargoWeight, cargoType);
                //make tires
                double tire1Pressure = double.Parse(input[5]);
                int tire1age = int.Parse(input[6]);
                double tire2Pressure = double.Parse(input[7]);
                int tire2age = int.Parse(input[8]);
                double tire3Pressure = double.Parse(input[9]);
                int tire3age = int.Parse(input[10]);
                double tire4Pressure = double.Parse(input[11]);
                int tire4age = int.Parse(input[12]);

                var currentTires = new Tire[4]
                {
                    new Tire(tire1Pressure, tire4age),
                    new Tire(tire2Pressure,tire2age),
                    new Tire(tire3Pressure, tire3age),
                    new Tire(tire4Pressure, tire3age)
                };
                //make car
                var currentCar = new Car(model, currentEngine, currentCargo, currentTires);
                cars.Add(currentCar);
            }

            string command = Console.ReadLine();
            if (command == "fragile")
            {
                Console.WriteLine(string.Join(Environment.NewLine, Fragile(cars)));
                
            }
            else
            {
                Console.WriteLine(string.Join(Environment.NewLine, Flamable(cars)));
            }
        }
        public static List<Car> Fragile(List<Car> cars)
        {
            var fragileCars = new List<Car>();
            fragileCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1)).ToList();
            return fragileCars;

        }
        public static List<Car> Flamable(List<Car> cars)
        {
            
            var flamableCars = new List<Car>();
            flamableCars = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
            return flamableCars;

        }
    }
}
