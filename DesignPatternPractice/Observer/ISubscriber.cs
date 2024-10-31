namespace DesignPatternPractice.Observer;
internal interface ISubscriber
{
    void OnPublisherNotify(object? sender, Dictionary<string, object> eventArgs);
}
