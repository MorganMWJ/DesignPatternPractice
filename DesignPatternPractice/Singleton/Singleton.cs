namespace DesignPatternPractice.Singleton;

/// <summary>
/// Example Singleton for reference.
/// This is not needed use static objects or .net DI singleton scope.
/// </summary>
internal class Singleton
{
    private static Singleton? Instance;

    private Singleton()
    {        
    }

    public Singleton GetInstance()
    {
        Instance ??= new Singleton();

        return Instance;
    }
}
