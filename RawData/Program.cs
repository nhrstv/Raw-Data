using System;
using System.Collections.Generic;
using System.Linq;

namespace RawData
{

    class Program
    {


        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] inputData = Console.ReadLine().Split();
                string model = inputData[0];
                int engineSpeed = int.Parse(inputData[1]);
                int enginePower = int.Parse(inputData[2]);
                int cargoWeight = int.Parse(inputData[3]);
                string cargoType = inputData[4];

                Engine engine = new Engine(engineSpeed, enginePower);
                Cargo cargo = new Cargo(cargoWeight, cargoType);
                int counter = 0;
                Tire[] tires = new Tire[4];
                for (int j = 5; j < inputData.Length; j += 2)
                {
                    double tire1Presure = double.Parse(inputData[j]);
                    int tir1Age = int.Parse(inputData[j + 1]);
                    Tire tire = new Tire(tir1Age, tire1Presure);
                    tires[counter++] = tire;


                }
                Car car = new Car(model, engine, cargo, tires);
                cars.Add(car);

            }

            string command = Console.ReadLine();
            if(command=="fragile")
            {
                var fragileCars = cars.Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(p=>p.Pressure<1)).ToList();
                foreach (var car in fragileCars)
                {
                    Console.WriteLine(car.Model);

                }

            }
            else
            {
                var flameable = cars.Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250).ToList();
                foreach (var car in flameable)
                {
                    Console.WriteLine(car.Model);

                }
            }
        }
    }
        
    
}
