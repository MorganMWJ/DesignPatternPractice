namespace DesignPatternPractice.Observer;
internal class EmailSubscriber : ISubscriber
{
    public void OnPublisherNotify(object? sender, Dictionary<string, object> eventArgs)
    {
        if (sender != null && sender is PersonPublisher)
        {
            if (eventArgs.TryGetValue("OnBoard", out var value))
            {
                var newPeople = value as List<Person>;
                Console.WriteLine($"Setting up email for {newPeople!.Count} people");
            }
            if (eventArgs.TryGetValue("OffBoard", out var value2))
            {
                var leavers = value as List<Person>;
                Console.WriteLine($"Archiving emails for {leavers!.Count} people");
            }
        }

        //else if (sender != null && sender is AnotherPublisher)
        //{
        //  Could subscribe to another publisher
        //}
    }
}
