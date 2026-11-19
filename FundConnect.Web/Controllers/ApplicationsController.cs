using FundConnect.Domain.Entities;
using FundConnect.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace FundConnect.Web.Controllers;

[Authorize(Roles = "BusinessOwner")]
public class ApplicationsController(FundConnectDbContext db) : Controller
{
    [HttpGet]
    public async Task<IActionResult> Create(int opportunityId)
    {
        var opportunity = await db.FundingOpportunities.FindAsync(opportunityId);
        if (opportunity is null || !opportunity.IsActive) return NotFound();
        ViewBag.Opportunity = opportunity;
        return View(new FundingApplication { FundingOpportunityId = opportunityId });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(FundingApplication model)
    {
        ModelState.Remove(nameof(model.ApplicantUserId));
        ModelState.Remove(nameof(model.BusinessProfile));
        ModelState.Remove(nameof(model.FundingOpportunity));

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        var business = await db.BusinessProfiles.FirstOrDefaultAsync(x => x.OwnerUserId == userId);
        var opportunity = await db.FundingOpportunities.FindAsync(model.FundingOpportunityId);

        if (business is null)
        {
            ModelState.AddModelError("", "Create your business profile before applying.");
        }
        if (opportunity is null || !opportunity.IsActive || opportunity.ClosingDate < DateTime.UtcNow)
        {
            ModelState.AddModelError("", "This funding opportunity is not accepting applications.");
        }
        if (business is not null && model.AmountRequested > business.FundingRequired)
            ModelState.AddModelError(nameof(model.AmountRequested), "Requested amount cannot exceed the amount in your business profile.");
        if (opportunity is not null && model.AmountRequested > opportunity.MaximumFunding)
            ModelState.AddModelError(nameof(model.AmountRequested), "Requested amount exceeds this opportunity's maximum funding.");

        if (!ModelState.IsValid)
        {
            ViewBag.Opportunity = opportunity;
            return View(model);
        }

        model.BusinessProfileId = business!.Id;
        model.ApplicantUserId = userId;
        model.Status = ApplicationStatus.Submitted;
        model.SubmittedAtUtc = DateTime.UtcNow;
        db.FundingApplications.Add(model);
        await db.SaveChangesAsync();
        TempData["Success"] = "Your application has been submitted.";
        return RedirectToAction("Index", "Dashboard");
    }
}
