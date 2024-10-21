using System.Reflection;

namespace DesignPatternPractice.Builder;

internal abstract class PaymentMessageBuilder : IPaymentMessageBuilder
{
    //maybe use type for this but simply string here
    protected string paymentMessage;
    protected bool withBasicInfo;
    protected bool withAuxInfo;

    public PaymentMessageBuilder()
    {
        paymentMessage = string.Empty;
        withBasicInfo = false;
        withAuxInfo = false;
    }

    public string Build()
    {
        if (!withBasicInfo)
        {
            throw new Exception("Cannot build unfinished payment message!");
        }

        return paymentMessage;
    }
    public abstract IPaymentMessageBuilder WithAuxillaryInformation(AuxillaryInfo auxillaryInfo);

    public abstract IPaymentMessageBuilder WithBasicInformation(BasicInfo basicInfo);

    /// <summary>
    /// I've decided to use Reflection in a generic method
    /// to map an action to each property in an object T
    /// Hopefully this doesn't distract from the builder pattern.
    /// Seems the most complicated part of this lololol ;)
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="action"></param>
    protected void ForEachProperty<T>(Action<PropertyInfo> action)
    {
        PropertyInfo[] properties = typeof(T).GetProperties();
        foreach (PropertyInfo property in properties)
        {
            action(property);
        }
    }
}
