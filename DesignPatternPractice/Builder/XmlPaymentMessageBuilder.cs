namespace DesignPatternPractice.Builder;

internal class XmlPaymentMessageBuilder : PaymentMessageBuilder
{
    public override IPaymentMessageBuilder WithAuxillaryInformation(AuxillaryInfo auxillaryInfo)
    {
        paymentMessage += "<AuxillaryInfo>\n";

        ForEachProperty<AuxillaryInfo>(prop =>
        {
            paymentMessage += $"<{prop.Name}>{prop.GetValue(auxillaryInfo)}<{prop.Name}/>\n";
        });

        paymentMessage += "<AuxillaryInfo/>\n";

        withAuxInfo = true;
        return this;
    }

    public override IPaymentMessageBuilder WithBasicInformation(BasicInfo basicInfo)
    {
        paymentMessage += "<BasicInfo>\n";

        ForEachProperty<BasicInfo>(prop =>
        {
            paymentMessage += $"<{prop.Name}>{prop.GetValue(basicInfo)}<{prop.Name}/>\n";
        });

        paymentMessage += "<BasicInfo/>\n";

        withBasicInfo = true;
        return this;
    }
}
