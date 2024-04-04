using System.Runtime.Intrinsics.Arm;
using System.Text;

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
    internal required string CarBrand { get; set; }

    internal required CarOwner Owner { get; set; }

    public new IDeepCloneable DeepClone()
    {
        var roadCar = new Car
        {
            Wheels = this.Wheels,
            Speed = this.Speed,
            Colour = this.Colour,
            CarBrand = this.CarBrand,
            Owner = new CarOwner
            {
                FirstName = this.Owner.FirstName,
                LastName = this.Owner.LastName
            }
        };
       

        return roadCar;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{nameof(Wheels)}: {Wheels}");
        sb.AppendLine($"{nameof(Speed)}: {Speed}");
        sb.AppendLine($"{nameof(CarBrand)}: {CarBrand}");
        sb.AppendLine($"{nameof(Colour)}: {Colour}");
        sb.AppendLine($"{nameof(Owner)}: {Owner.FirstName} {Owner.LastName}");

        return sb.ToString();
    }
}


internal class CarOwner
{
    internal string FirstName { get; set; }
    internal string LastName { get; set; }
}
