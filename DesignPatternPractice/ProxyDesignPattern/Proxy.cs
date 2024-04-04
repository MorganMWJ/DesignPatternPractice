namespace DesignPatternPractice.ProxyDesignPattern;

internal class Proxy : IMyExternalService
{

    private readonly IMyExternalService _service;

    public Proxy(IMyExternalService service)
    {
        _service = service;
    }

    public void Operation(object param)
    {
        Console.WriteLine("Proxy service: Do something before execution. Maybe save param?");

        _service.Operation(param);

        Console.WriteLine("Proxy service: Do something after execution. Maybe log something? result?");
    }
}

internal class MyExternalService : IMyExternalService
{
    public void Operation(object param)
    {
        Console.WriteLine("Original Service: operation execution.");
    }
}

internal interface IMyExternalService 
{
    void Operation(object param);
}

