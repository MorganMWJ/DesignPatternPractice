
namespace DesignPatternPractice.Bridge;

/// <summary>
/// Goes from using inheritance to object compososition (dependency)
/// To prevent large inheritance hierarchy due to combinations of
/// types.
/// 
/// In DP terms the Abstraction is the class that holds 
/// the reference/dependency (bridge) the implementation
/// is the dependency class.
/// </summary>
internal class AbstractionSideOfBridge
{
    // dependency is the 'bridge'
    private readonly IImplementationSideOfBridge _bridge;

    public AbstractionSideOfBridge(IImplementationSideOfBridge bridge)
    {
        _bridge = bridge;
    }

    public void OperationForUseByClient()
    {
        _bridge.Operation1();
        _bridge.Operation2();
        _bridge.Operation1();
    } 
}



internal interface IImplementationSideOfBridge 
{
    void Operation1();

    void Operation2();
}

internal class NiceDependencySideImplementation : IImplementationSideOfBridge
{
    public void Operation1()
    {
        Console.WriteLine("Cześć");
    }

    public void Operation2()
    {
        Console.WriteLine("Moja miłość");
    }
}

internal class NastyDependencySideImplementation : IImplementationSideOfBridge
{
    public void Operation1()
    {
        Console.WriteLine("Be Silent!");
    }

    public void Operation2()
    {
        Console.WriteLine("Keep your fallen tounge behind your teeth!");
    }
}

