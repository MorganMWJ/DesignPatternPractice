namespace DesignPatternPractice.ChainOfResponsibility;
internal class HighQuantityOrderHandler : OrderHandler
{
    public override void Handle(OrderRequest request)
    {
        Console.WriteLine($"At {nameof(HighQuantityOrderHandler)}");

        if (!ShouldHandle(request))
        {
            Next!.Handle(request);
            return;
        }

        Console.WriteLine("High order quantity detected.");
        Console.WriteLine("Splitiing order into multiple dispatches.");
    }

    private bool ShouldHandle(OrderRequest request)
    {
        return request.Quantity >= 1000;
    }
}
