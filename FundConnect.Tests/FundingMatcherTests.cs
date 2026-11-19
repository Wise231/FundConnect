using FundConnect.Application.Matching;
using FundConnect.Domain.Entities;
using Xunit;

namespace FundConnect.Tests;

public class FundingMatcherTests
{
    [Fact]
    public void Evaluate_ReturnsFullMatch_WhenAllRequirementsAreMet()
    {
        var business = new BusinessProfile
        {
            Industry = "Information Technology",
            Province = "Eastern Cape",
            AnnualTurnover = 300000,
            YearsOperating = 3
        };
        var opportunity = new FundingOpportunity
        {
            Industry = "Information Technology",
            Province = "Any",
            MinimumTurnover = 100000,
            MinimumOperatingYears = 2
        };

        var result = new FundingMatcher().Evaluate(business, opportunity);

        Assert.Equal(100, result.Score);
        Assert.True(result.MeetsMandatoryRequirements);
    }

    [Fact]
    public void Evaluate_FailsMandatoryRequirement_WhenTurnoverIsTooLow()
    {
        var business = new BusinessProfile
        {
            Industry = "Information Technology",
            Province = "Eastern Cape",
            AnnualTurnover = 50000,
            YearsOperating = 3
        };
        var opportunity = new FundingOpportunity
        {
            Industry = "Information Technology",
            Province = "Any",
            MinimumTurnover = 100000,
            MinimumOperatingYears = 2
        };

        var result = new FundingMatcher().Evaluate(business, opportunity);

        Assert.False(result.MeetsMandatoryRequirements);
        Assert.Contains(result.Reasons, reason => reason.Contains("turnover"));
    }
}
