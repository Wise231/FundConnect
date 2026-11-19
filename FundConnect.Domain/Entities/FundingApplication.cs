namespace FundConnect.Domain.Entities;

public enum ApplicationStatus
{
    Submitted,
    UnderReview,
    MoreInformationRequired,
    Approved,
    Declined
}

public class FundingApplication
{
    public int Id { get; set; }
    public int BusinessProfileId { get; set; }
    public BusinessProfile? BusinessProfile { get; set; }
    public int FundingOpportunityId { get; set; }
    public FundingOpportunity? FundingOpportunity { get; set; }
    public string ApplicantUserId { get; set; } = "";
    public decimal AmountRequested { get; set; }
    public string Motivation { get; set; } = "";
    public ApplicationStatus Status { get; set; } = ApplicationStatus.Submitted;
    public DateTime SubmittedAtUtc { get; set; } = DateTime.UtcNow;
}
