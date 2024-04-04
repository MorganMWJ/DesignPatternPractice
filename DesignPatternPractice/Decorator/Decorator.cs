namespace DesignPatternPractice.Decorator;

// Component interface
interface ICar
{
    void Assemble();
}

// Concrete component
class BasicCar : ICar
{
    public void Assemble()
    {
        Console.WriteLine("Basic Car");
    }
}

/// <summary>
/// The decorator design pattern is a structural pattern that allows behavior
/// to be added to individual objects, dynamically, without affecting the behavior 
/// of other objects from the same class. It's useful when you need to add functionality 
/// to objects at runtime or when you have a large number of optional features that can be added to an object.
/// </summary>
abstract class CarDecorator : ICar
{
    protected ICar car;

    public CarDecorator(ICar car)
    {
        this.car = car;
    }

    public virtual void Assemble()
    {
        car.Assemble();
    }
}

// Concrete decorator
class SportsCar : CarDecorator
{
    public SportsCar(ICar car) : base(car) { }

    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding features of Sports Car");
    }
}

// Concrete decorator
class LuxuryCar : CarDecorator
{
    public LuxuryCar(ICar car) : base(car) { }

    public override void Assemble()
    {
        base.Assemble();
        Console.WriteLine("Adding features of Luxury Car");
    }
}