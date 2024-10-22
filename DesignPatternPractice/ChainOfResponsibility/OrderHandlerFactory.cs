namespace DesignPatternPractice.ChainOfResponsibility;
internal class OrderHandlerFactory
{
    /// <summary>
    /// Set up the chain of responsibility
    /// </summary>
    /// <returns></returns>
    public IOrderHandler CreateOrderCOR()
    {
        var h1 = new HighValueOrderHandler();
        var h2 = new HighQuantityOrderHandler();
        var h3 = new StandardOrderHandler();

        h1.SetNext(h2);
        h2.SetNext(h3);

        return h1;
    }
}
