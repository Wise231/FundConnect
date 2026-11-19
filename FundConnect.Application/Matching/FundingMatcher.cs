using FundConnect.Domain.Entities;

namespace FundConnect.Application.Matching;

public class FundingMatcher
{
    public FundingMatchResult Evaluate(BusinessProfile business, FundingOpportunity opportunity)
    {
        var reasons = new List<string>();
        var score = 0;
        var mandatory = true;

        if (Matches(opportunity.Industry, business.Industry))
        {
            score += 30;
            reasons.Add("Industry requirement matches.");
        }
        else if (!IsAny(opportunity.Industry))
        {
            mandatory = false;
            reasons.Add("Industry does not match.");
        }

        if (Matches(opportunity.Province, business.Province))
        {
            score += 20;
            reasons.Add("Location requirement matches.");
        }
        else if (!IsAny(opportunity.Province))
        {
            mandatory = false;
            reasons.Add("Province does not match.");
        }

        if (business.AnnualTurnover >= opportunity.MinimumTurnover)
        {
            score += 25;
            reasons.Add("Turnover threshold is met.");
        }
        else
        {
            mandatory = false;
            reasons.Add("Minimum turnover is not met.");
        }

        if (business.YearsOperating >= opportunity.MinimumOperatingYears)
        {
            score += 25;
            reasons.Add("Operating history requirement is met.");
        }
        else
        {
            mandatory = false;
            reasons.Add("Minimum operating history is not met.");
        }

        return new FundingMatchResult(opportunity, score, mandatory, reasons);
    }

    private static bool IsAny(string value) =>
        string.IsNullOrWhiteSpace(value) || value.Equals("Any", StringComparison.OrdinalIgnoreCase);

    private static bool Matches(string required, string actual) =>
        IsAny(required) || required.Equals(actual, StringComparison.OrdinalIgnoreCase);
}
