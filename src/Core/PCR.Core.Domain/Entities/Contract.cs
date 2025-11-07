namespace PCR.Core.Domain.Entities;

public class Contract : AuditableEntity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public Guid ClientId { get; set; }
    public Client Client { get; set; } = null!;
    public ContractStatus Status { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int TermMonths { get; set; }
    public decimal MonthlyEnergy { get; set; }
    public decimal AnnualEnergy { get; set; }
    public decimal Price1 { get; set; }
    public decimal Price2 { get; set; }
    public decimal RemPrice { get; set; }
    public string Currency { get; set; } = "USD";
    public string PaymentTerm { get; set; } = string.Empty;
    public string Guarantees { get; set; } = string.Empty;
    public List<string> Nemonics { get; set; } = new();
    public List<string> Concepts { get; set; } = new();
    public List<decimal> MonthlySchedule { get; set; } = new();
}

public enum ContractStatus
{
    Draft,
    Active,
    Expired
}