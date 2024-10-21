namespace DesignPatternPractice.Builder;

public class BasicInfo
{
    public required string Debtor {  get; set; }
    public required string Creditor {  get; set; }
    public double Amount {  get; set; }
    public required string Currency {  get; set; }
    public DateTime? Date {  get; set; }
}