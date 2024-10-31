namespace DesignPatternPractice.Observer;

/// <summary>
/// Pub-sub base class
/// Using events to hold list of subscribing actions to call,
/// instead of list of subscriber objects.
/// </summary>
internal abstract class Publisher
{
    /// <summary>
    /// A event (multi-cast) delegate that holds a list of methods to invoke.
    /// These methods are the subscribers. 
    /// 
    /// Using the EventHandler delegate with a custom event arg type of Dictionary.
    /// You can also optionally pass the sender object that notified/published.
    /// 
    /// This event is nullable as no subscriber actions will be registered on construction.
    /// </summary>
    private event EventHandler<Dictionary<string, object>>? NotifySubscribersEvent;

    public void Subscribe(ISubscriber subscriber)
    {
        NotifySubscribersEvent += subscriber.OnPublisherNotify;
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        NotifySubscribersEvent -= subscriber.OnPublisherNotify;
    }

    protected void NotifySubscribers(Dictionary<string, object> context)
    {
        NotifySubscribersEvent?.Invoke(null, context);
    }

    protected void NotifySubscribers(object? sender, Dictionary<string, object> context)
    {
        NotifySubscribersEvent?.Invoke(sender, context);
    }
}
