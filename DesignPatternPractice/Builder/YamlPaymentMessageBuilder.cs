namespace DesignPatternPractice.Builder;

internal class YamlPaymentMessageBuilder : PaymentMessageBuilder
{
    public YamlPaymentMessageBuilder() : base()
    {
    }

    public override IPaymentMessageBuilder WithAuxillaryInformation(AuxillaryInfo auxillaryInfo)
    {
        ForEachProperty<AuxillaryInfo>(prop =>
        {
            paymentMessage += $"\"{prop.Name}\": \"{prop.GetValue(auxillaryInfo)}\"\n";
        });

        withAuxInfo = true;
        return this;
    }

    public override IPaymentMessageBuilder WithBasicInformation(BasicInfo basicInfo)
    {
        ForEachProperty<BasicInfo>(prop =>
        {
            paymentMessage += $"\"{prop.Name}\": \"{prop.GetValue(basicInfo)}\"\n";
        });

        withBasicInfo = true;
        return this;
    }
}
