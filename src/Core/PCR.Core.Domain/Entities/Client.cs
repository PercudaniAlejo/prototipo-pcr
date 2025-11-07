namespace PCR.Core.Domain.Entities;

public class Client : AuditableEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public bool Enabled { get; set; }
    public bool Active { get; set; }
    public ICollection<Contract> Contracts { get; set; } = new List<Contract>();
}