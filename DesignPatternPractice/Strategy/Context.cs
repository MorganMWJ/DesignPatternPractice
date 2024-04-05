namespace DesignPatternPractice.Strategy;

/// <summary>
/// The Context maintains a reference to one of the concrete strategies 
/// and communicates with this object only via the strategy interface.
/// 
/// The context also holds other context info required by the strategy? Data to be passed?
/// Or it can just have the caller pass the data. Here the data is stored as 2 decimal proepries.
/// </summary>
internal class Context
{
    //Holds concrete strategy
    public IStrategy Strategy { get; set; }


    //Data
    public decimal FrequencyData { get; set; } = 10.1m;
    public decimal SpeedData { get; set; } = 3.0m;

    public Context(IStrategy strategy)
    {
        Strategy = strategy;
    }

    public Context()
    {
    }

    public decimal CombineData()
    {
        return Strategy.Execute(FrequencyData, SpeedData);
    }
}
