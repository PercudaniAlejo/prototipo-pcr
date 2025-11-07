namespace PCR.Core.Domain.Entities;

public class Rate : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public decimal Value { get; set; }
    public DateTime? ValidUntil { get; set; }
}