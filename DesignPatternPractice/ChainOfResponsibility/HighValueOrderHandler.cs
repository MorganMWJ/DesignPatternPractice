namespace DesignPatternPractice.ChainOfResponsibility;
internal class HighValueOrderHandler : OrderHandler
{
    public override void Handle(OrderRequest request)
    {
        Console.WriteLine($"At {nameof(HighValueOrderHandler)}");

        if (!ShouldHandle(request))
        {
            Next!.Handle(request);
            return;
        }

        Console.WriteLine("High order value detected.");
        Console.WriteLine("Sending order for extra financial checks.");
    }

    private bool ShouldHandle(OrderRequest request)
    {
        return request.Price >= 10_000.00m;
    }
}
