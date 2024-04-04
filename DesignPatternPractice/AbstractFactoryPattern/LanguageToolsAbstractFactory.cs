namespace DesignPatternPractice.AbstractFactoryPattern
{
    /// <summary>
    /// Abstract factory creates a factory with methods 
    /// for creating a set of dervied objects that
    /// beloing together.
    /// </summary>
    internal interface ILanguageToolsAbstractFactory
    {
        IParser CreateParser();
        IEvaluator CreateEvaluator();
    }

    /// <summary>
    /// Concrete factory creates IEvaluator & IParser specific to Python
    /// </summary>
    internal class PythonLanguageToolFactory : ILanguageToolsAbstractFactory
    {
        public IEvaluator CreateEvaluator()
        {
            return new TypeSafeEvaluator();
        }

        public IParser CreateParser()
        {
            return new PascalCaseParser();
        }
    }

    /// <summary>
    /// Concrete factory creates IEvaluator & IParser specific to C#
    /// </summary>
    internal class CSharpLanguageToolFactory : ILanguageToolsAbstractFactory
    {
        public IEvaluator CreateEvaluator()
        {
            return new DynamicallyTypedEvaluator();
        }

        public IParser CreateParser()
        {
            return new SnakeCaseParser();
        }
    }
}
