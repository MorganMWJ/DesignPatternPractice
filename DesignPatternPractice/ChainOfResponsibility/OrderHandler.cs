namespace DesignPatternPractice.ChainOfResponsibility;

internal abstract class OrderHandler : IOrderHandler
{
    protected IOrderHandler? Next { get; private set; }

    public abstract void Handle(OrderRequest request);

    public void SetNext(IOrderHandler nextHandler)
    {
        Next = nextHandler;
    }
}
