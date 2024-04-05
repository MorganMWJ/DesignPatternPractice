﻿using DesignPatternPractice.Bridge;
using DesignPatternPractice.Decorator;
using DesignPatternPractice.Facade;
using DesignPatternPractice.Iterator;
using DesignPatternPractice.ProxyDesignPattern;
using DesignPatternPractice.Strategy;
using MorganMWJ.DesignPatternPracitce.Prototype_Clone;
using MorganMWJ.HelpersPkg;

namespace DesignPatternPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("This program demos the follow design patterns.");
            //Methods.PrintArgument("Decorator", "Facade", "Proxy", "Bridge", "Prototype/Clone");


            DecoratorUsage();

            Console.WriteLine("----------------------");

            FacadeUsage();

            Console.WriteLine("----------------------");

            ProxyUsage();

            Console.WriteLine("----------------------");

            BridgeUsage();

            Console.WriteLine("----------------------");

            CloneUsage();

            Console.WriteLine("----------------------");

            StrategyUsage();
        }

        static void DecoratorUsage()
        {
            // Create a basic car
            ICar basicCar = new BasicCar();
            basicCar.Assemble();

            Console.WriteLine();

            // Decorate the basic car with sports car features
            ICar sportsCar = new SportsCar(new BasicCar());
            sportsCar.Assemble();

            Console.WriteLine();

            // Decorate the basic car with luxury car features
            ICar luxuryCar = new LuxuryCar(new BasicCar());
            luxuryCar.Assemble();

            Console.WriteLine();

            // Decorate the basic car with luxury car features & then sports car features
            ICar luxurySportCar = new SportsCar(new LuxuryCar(new BasicCar()));
            luxurySportCar.Assemble();
        }

        static void FacadeUsage()
        {
            // Client code using the facade
            var facade = new Facade.Facade();
            facade.Operation();
        }

        static void ProxyUsage()
        {
            var proxy = new Proxy(new MyExternalService());
            proxy.Operation("test param");
        }

        static void BridgeUsage()
        {
            var bridgeToNicePerson = new AbstractionSideOfBridge(new NiceDependencySideImplementation());

            bridgeToNicePerson.OperationForUseByClient();

            var bridgeToNastyPerson = new AbstractionSideOfBridge(new NastyDependencySideImplementation());

            bridgeToNastyPerson.OperationForUseByClient();
        }

        static void CloneUsage()
        {
            var car = new Car
            {
                Wheels = 4,
                Colour = "Red",
                Speed = 81.12m,
                CarBrand = "Suzuki",
                Owner = new CarOwner { FirstName = "Morgan", LastName = "Jones"}
            };

            Console.WriteLine($"First car (memory address: {StaticHelpers.GetMemoryAddress(car)})");
            Console.WriteLine(car);

            var carClone = car.DeepClone();

            Console.WriteLine($"DeepClone of car (memory address: {StaticHelpers.GetMemoryAddress(carClone)})");
            Console.WriteLine(carClone);


            // test enumerator

            var car2 = new Car
            {
                Wheels = 4,
                Colour = "Black",
                Speed = 100.12m,
                CarBrand = "Audi",
                Owner = new CarOwner { FirstName = "Joel", LastName = "Jones" }
            };

            var cars = new Cars([car, car2]);
            foreach (var c in cars)
            {
                Console.WriteLine(c);
            }
        }
        
        static void StrategyUsage()
        {
            var arithmeticContext = new Context();

            arithmeticContext.Strategy = new MultiplyStrategy();

            Console.WriteLine($"Data {arithmeticContext.FrequencyData} and {arithmeticContext.SpeedData} returns {arithmeticContext.CombineData()} when using {nameof(MultiplyStrategy)}");

            arithmeticContext.Strategy = new AddStrategy();

            Console.WriteLine($"Data {arithmeticContext.FrequencyData} and {arithmeticContext.SpeedData} returns {arithmeticContext.CombineData()} when using {nameof(AddStrategy)}");

            arithmeticContext.Strategy = new SubtractStrategy();

            Console.WriteLine($"Data {arithmeticContext.FrequencyData} and {arithmeticContext.SpeedData} returns {arithmeticContext.CombineData()} when using {nameof(SubtractStrategy)}");

        }
    }
}
