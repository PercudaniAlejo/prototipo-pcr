namespace PCR.Core.Domain.Entities;

public abstract class AuditableEntity : BaseEntity
{
    public string? DeletedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
}
