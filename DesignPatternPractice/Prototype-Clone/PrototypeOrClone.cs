using System.Runtime.Intrinsics.Arm;

namespace DesignPatternPractice.Prototype_Clone;

/// <summary>
/// This pattern is how to create an exact copy of an object. (i.e cloneable)
/// This is the prototype, the interface that implements the cloning.
/// </summary>
internal interface IDeepCloneable
{
    IDeepCloneable DeepClone();
}

internal class RoadVehicle : IDeepCloneable
{
    internal int Wheels { get; set; }

    internal decimal Speed { get; set; }

    internal required string Colour { get; set; }

    public virtual IDeepCloneable DeepClone()
    {
        return new RoadVehicle 
        {
            Wheels = this.Wheels,
            Speed = this.Speed,
            Colour = this.Colour 
        };

    }
}


internal class Car : RoadVehicle
{
    internal string CarBrand { get; set; }

    internal CarOwner Owner { get; set; }

    public new IDeepCloneable DeepClone()
    {
        var roadCar = (Car) base.DeepClone();
        roadCar.CarBrand = this.CarBrand;
        roadCar.Owner = new CarOwner
        {
            FirstName = this.Owner.FirstName,
            LastName = this.Owner.LastName
        };

        return roadCar;
    }
}


internal class CarOwner
{
    internal string FirstName { get; set; }
    internal string LastName { get; set; }
}
