namespace DesignPatternPractice.Observer;

internal record Person(string Name, int Age);

internal class PersonPublisher : Publisher
{
    public List<Person> People { get; set; }

    public PersonPublisher()
    {
        People = new List<Person>();
    }

    /// <summary>
    /// Action that notifies subscribers.
    /// </summary>
    /// <param name="newPeople"></param>
    public void OnBoard(List<Person> newPeople)
    {
        People.AddRange(newPeople);

        // Adding method name and parameter as event args
        var eventArgs = new Dictionary<string, object>
        {
            { "OnBoard", newPeople}
        };

        // this class is the sender to publish/notify event
        NotifySubscribers(this, eventArgs);
    }

    /// <summary>
    /// Action that notifies subscribers.
    /// </summary>
    /// <param name="newPeople"></param>
    public void OffBoard(List<Person> people)
    {
        foreach (var person in People)
        {
            People.Remove(person);
        }

        // Adding method name and parameter as event args
        var eventArgs = new Dictionary<string, object>
        {
            { "OffBoard", people}
        };

        // this class is the sender to publish/notify event
        NotifySubscribers(this, eventArgs);
    }

    /// <summary>
    /// Action that notifies subscribers.
    /// </summary>
    public void Birthday(Person p)
    {
        // Adding method name and parameter as event args
        var eventArgs = new Dictionary<string, object>
        {
            { "Birthday", p}
        };

        // this class is the sender to publish/notify event
        NotifySubscribers(this, eventArgs);
    }
}
