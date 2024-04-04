namespace DesignPatternPractice.Facade;

/// <summary>
/// The facade design pattern is a structural pattern that provides a simplified interface to a larger body of code,
/// such as a complex subsystem, making it easier to use. It encapsulates a complex set of interactions into a single interface,
/// providing a higher-level interface that makes the subsystem easier to use and understand.
/// </summary>
class Facade
{
    private SubsystemA subsystemA;
    private SubsystemB subsystemB;
    private SubsystemC subsystemC;

    public Facade()
    {
        subsystemA = new SubsystemA();
        subsystemB = new SubsystemB();
        subsystemC = new SubsystemC();
    }

    // Method that encapsulates complex subsystem interactions
    public void Operation()
    {
        Console.WriteLine("Facade operation:");
        subsystemA.OperationA();
        subsystemB.OperationB();
        subsystemC.OperationC();
    }
}

// Complex subsystem classes
class SubsystemA
{
    public void OperationA()
    {
        Console.WriteLine("Subsystem A operation");
    }
}

class SubsystemB
{
    public void OperationB()
    {
        Console.WriteLine("Subsystem B operation");
    }
}

class SubsystemC
{
    public void OperationC()
    {
        Console.WriteLine("Subsystem C operation");
    }
}