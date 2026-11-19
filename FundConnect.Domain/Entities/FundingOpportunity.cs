namespace FundConnect.Domain.Entities;

public class FundingOpportunity
{
    public int Id { get; set; }
    public string Title { get; set; } = "";
    public string Provider { get; set; } = "";
    public string Description { get; set; } = "";
    public string Industry { get; set; } = "Any";
    public string Province { get; set; } = "Any";
    public decimal MinimumTurnover { get; set; }
    public decimal MaximumFunding { get; set; }
    public int MinimumOperatingYears { get; set; }
    public DateTime ClosingDate { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
