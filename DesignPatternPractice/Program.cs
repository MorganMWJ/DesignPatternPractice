using DesignPatternPractice.Bridge;
using DesignPatternPractice.Decorator;
using DesignPatternPractice.Facade;
using DesignPatternPractice.ProxyDesignPattern;

namespace DesignPatternPractice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DecoratorUsage();

            Console.WriteLine("----------------------");

            FacadeUsage();

            Console.WriteLine("----------------------");

            ProxyUsage();

            Console.WriteLine("----------------------");

            BridgeUsage();
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
            Facade.Facade facade = new Facade.Facade();
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

        }
    }
}
