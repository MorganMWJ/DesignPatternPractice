namespace DesignPatternPractice.Builder;

internal interface IPaymentMessageBuilder
{
    IPaymentMessageBuilder WithBasicInformation(BasicInfo basicInfo);

    IPaymentMessageBuilder WithAuxillaryInformation(AuxillaryInfo auxillaryInfo);

    string Build();
}
