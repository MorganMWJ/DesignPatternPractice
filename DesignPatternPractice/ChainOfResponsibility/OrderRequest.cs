namespace DesignPatternPractice.ChainOfResponsibility;

public record OrderRequest(Guid Id, string Item, decimal Price, int Quantity, string Notes);
