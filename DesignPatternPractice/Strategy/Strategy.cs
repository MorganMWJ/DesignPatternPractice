namespace DesignPatternPractice.Strategy;

internal interface IStrategy
{
    decimal Execute(decimal a, decimal b);
}

internal class AddStrategy : IStrategy
{
    public decimal Execute(decimal a, decimal b)
    {
        return a + b;
    }
}

internal class SubtractStrategy : IStrategy
{
    public decimal Execute(decimal a, decimal b)
    {
        return a - b;
    }
}

internal class MultiplyStrategy : IStrategy
{
    public decimal Execute(decimal a, decimal b)
    {
        return a * b;
    }
}