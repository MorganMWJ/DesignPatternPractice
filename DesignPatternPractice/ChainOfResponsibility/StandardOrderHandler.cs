namespace DesignPatternPractice.ChainOfResponsibility;

internal class StandardOrderHandler : OrderHandler
{
    public override void Handle(OrderRequest request)
    {
        Console.WriteLine($"At {nameof(StandardOrderHandler)}");
        Console.WriteLine("Standard order detected.");
    }
}
