namespace DesignPatternPractice.ChainOfResponsibility;

internal interface IOrderHandler
{
    void SetNext(IOrderHandler nextHandler);

    void Handle(OrderRequest request);
}
