namespace DesignPatternPractice.AbstractFactoryPattern;

public interface IEvaluator
{
    void Evaluate();
}

internal class TypeSafeEvaluator : IEvaluator
{
    public void Evaluate()
    {
        throw new NotImplementedException();
    }
}

internal class DynamicallyTypedEvaluator : IEvaluator
{
    public void Evaluate()
    {
        throw new NotImplementedException();
    }
}
