namespace FundConnect.Domain.Entities;

public class BusinessProfile
{
    public int Id { get; set; }
    public string OwnerUserId { get; set; } = "";
    public string BusinessName { get; set; } = "";
    public string RegistrationNumber { get; set; } = "";
    public string Industry { get; set; } = "";
    public string Province { get; set; } = "";
    public decimal AnnualTurnover { get; set; }
    public int YearsOperating { get; set; }
    public decimal FundingRequired { get; set; }
    public string Description { get; set; } = "";
    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;
}
