using FundConnect.Domain.Entities;
using FundConnect.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FundConnect.Infrastructure.Data;

public class FundConnectDbContext(DbContextOptions<FundConnectDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<BusinessProfile> BusinessProfiles => Set<BusinessProfile>();
    public DbSet<FundingOpportunity> FundingOpportunities => Set<FundingOpportunity>();
    public DbSet<FundingApplication> FundingApplications => Set<FundingApplication>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<BusinessProfile>().Property(x => x.AnnualTurnover).HasPrecision(18, 2);
        builder.Entity<BusinessProfile>().Property(x => x.FundingRequired).HasPrecision(18, 2);
        builder.Entity<FundingOpportunity>().Property(x => x.MinimumTurnover).HasPrecision(18, 2);
        builder.Entity<FundingOpportunity>().Property(x => x.MaximumFunding).HasPrecision(18, 2);
        builder.Entity<FundingApplication>().Property(x => x.AmountRequested).HasPrecision(18, 2);

        builder.Entity<FundingApplication>()
            .HasOne(x => x.BusinessProfile)
            .WithMany()
            .HasForeignKey(x => x.BusinessProfileId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FundingApplication>()
            .HasOne(x => x.FundingOpportunity)
            .WithMany()
            .HasForeignKey(x => x.FundingOpportunityId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<FundingOpportunity>().HasData(
            new FundingOpportunity
            {
                Id = 1, Title = "Technology Growth Grant", Provider = "Example Development Agency",
                Description = "Illustrative funding opportunity for qualifying technology businesses.",
                Industry = "Information Technology", Province = "Any", MinimumTurnover = 100000,
                MaximumFunding = 500000, MinimumOperatingYears = 1,
                ClosingDate = new DateTime(2027, 6, 30), IsActive = true,
                CreatedAtUtc = new DateTime(2026, 11, 18)
            },
            new FundingOpportunity
            {
                Id = 2, Title = "Small Business Expansion Fund", Provider = "Example Enterprise Fund",
                Description = "Illustrative expansion support for established small businesses.",
                Industry = "Any", Province = "Western Cape", MinimumTurnover = 250000,
                MaximumFunding = 250000, MinimumOperatingYears = 2,
                ClosingDate = new DateTime(2027, 3, 31), IsActive = true,
                CreatedAtUtc = new DateTime(2026, 11, 18)
            });
    }
}
