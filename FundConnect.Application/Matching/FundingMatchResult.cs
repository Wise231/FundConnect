using FundConnect.Domain.Entities;

namespace FundConnect.Application.Matching;

public record FundingMatchResult(FundingOpportunity Opportunity, int Score, bool MeetsMandatoryRequirements, IReadOnlyList<string> Reasons);
