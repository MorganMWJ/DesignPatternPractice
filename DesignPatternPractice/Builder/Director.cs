namespace DesignPatternPractice.Builder;

/// <summary>
/// Director is class that uses the builder
/// </summary>
internal class Director
{
    internal IPaymentMessageBuilder PaymentMessageBuilder { get; set; }

    internal Director(IPaymentMessageBuilder builder)
    {
        PaymentMessageBuilder = builder;
    }

    internal string ConstructBasicPaymentMessage(BasicInfo basicInfo)
    {
        return PaymentMessageBuilder.WithBasicInformation(basicInfo).Build();
    }

    internal string ConstructAdvancedPaymentMessage(BasicInfo basicInfo, AuxillaryInfo auxillaryInfo)
    {
        return PaymentMessageBuilder
            .WithBasicInformation(basicInfo)
            .WithAuxillaryInformation(auxillaryInfo)
            .Build();
    }
}
