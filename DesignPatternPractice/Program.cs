using DesignPatternPractice.Bridge;
using DesignPatternPractice.Decorator;
using DesignPatternPractice.Facade;
using DesignPatternPractice.Prototype_Clone;
using DesignPatternPractice.ProxyDesignPattern;

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

            Console.WriteLine($"First car (memory address: {Methods.GetMemoryAddress(car)})");
            Console.WriteLine(car);

            var carClone = car.DeepClone();

            Console.WriteLine($"DeepClone of car (memory address: {Methods.GetMemoryAddress(carClone)})");
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
    }
}
