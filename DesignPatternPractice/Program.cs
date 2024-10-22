using DesignPatternPractice.Bridge;
using DesignPatternPractice.Builder;
using DesignPatternPractice.ChainOfResponsibility;
using DesignPatternPractice.Decorator;
using DesignPatternPractice.Facade;
using DesignPatternPractice.Iterator;
using DesignPatternPractice.Memento;
using DesignPatternPractice.ProxyDesignPattern;
using DesignPatternPractice.Strategy;
using DesignPatternPractice.TreeIterator;
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

            Console.WriteLine("----------------------");

            MementoUsage();

            Console.WriteLine("----------------------");

            TreeNodeUsage();

            Console.WriteLine("----------------------");

            BuilderUsage();

            Console.WriteLine("----------------------");

            ChainOfResponsibilityUsage();
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

        /// <summary>
        /// Very similar to stragety just a dependency of many types (ploymorph)
        /// Although structural because dependency goes into constructor and is only settable through that. cannot dynamically change implementation (unlike strategy)
        /// </summary>
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
        
        /// <summary>
        /// Very similar to bridge just a dependency of many types (ploymorph)
        /// Although behavioural because settable at runtime. less coupling?
        /// </summary>
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


        static void MementoUsage()
        {
            Console.WriteLine("Initial State:");
            var gameClient = new GameClient();
            Console.WriteLine(gameClient);

            Console.WriteLine("Level Up 3 times:");
            gameClient.LevelUpAndSave();
            Console.WriteLine(gameClient);

            gameClient.LevelUpAndSave();
            Console.WriteLine(gameClient);

            gameClient.LevelUpAndSave();
            Console.WriteLine(gameClient);


            Console.WriteLine("Reset player state/saves by 2:");
            gameClient.UndoPlayerSave(2);
            Console.WriteLine(gameClient);
        }

        static void TreeNodeUsage()
        {
            TreeNode<string> root = new TreeNode<string>("Root");
            TreeNode<string> child1 = new TreeNode<string>("Child 1", root);
            TreeNode<string> child2 = new TreeNode<string>("Child 2", root);
            TreeNode<string> leaf1 = new TreeNode<string>("Leaf 1", child1);
            TreeNode<string> leaf2 = new TreeNode<string>("Leaf 2", child1);
            TreeNode<string> leaf3 = new TreeNode<string>("Leaf 3", child2);

            // Build the tree
            root.AddChild(child1);
            root.AddChild(child2);
            child1.AddChild(leaf1);
            child1.AddChild(leaf2);
            child2.AddChild(leaf3);

            // Iterate using depth-first traversal
            foreach (var node in root)
            {
                Console.WriteLine(node.Value);
            }

            // Strategy Design Pattern to set breadth first search iteration
            root.IterationStrategy = new BreadthFirstStrategy<string>();

            // Iterate using breadth-first traversal
            foreach (var node in root)
            {
                Console.WriteLine(node.Value);
            }
        }

        static void BuilderUsage()
        {
            var director = new Director(new XmlPaymentMessageBuilder());

            var bi = new BasicInfo
            {
                Creditor = "me",
                Debtor = "dude",
                Date = DateTime.Now,
                Currency = "GBP",
                Amount = 23.09
            };

            var ai = new AuxillaryInfo
            {
                Notes = "Thanks mate",
                Address = "23 Zoo Lane, NP55 8UI"
            };

            Console.WriteLine("Using XML builder");
            Console.WriteLine(director.ConstructBasicPaymentMessage(bi));
            Console.WriteLine(director.ConstructAdvancedPaymentMessage(bi, ai));

            director.PaymentMessageBuilder = new YamlPaymentMessageBuilder();

            Console.WriteLine("Using YAML builder");
            Console.WriteLine(director.ConstructBasicPaymentMessage(bi));
            Console.WriteLine(director.ConstructAdvancedPaymentMessage(bi, ai));
        }

        static void ChainOfResponsibilityUsage()
        {
            var handler = new OrderHandlerFactory().CreateOrderCOR();

            var request = new OrderRequest(new Guid(), "Peace Lily", 45.90m, 2040, "Good luck");

            // Cannot use Object Inititialization syntax without a parameterless constructor
            //var request2 = new OrderRequest
            //{
            //    Id = Guid.NewGuid(),
            //    Item = "Peace Lily",
            //    Price = 45.90m,
            //    Quantity = 2040,
            //    Notes = "Good luck"
            //};

            handler.Handle(request);
        }
    }
}
