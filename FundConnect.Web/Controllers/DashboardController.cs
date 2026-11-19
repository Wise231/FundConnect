using FundConnect.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundConnect.Web.Controllers;

[Authorize]
public class DashboardController(FundConnectDbContext db) : Controller
{
    public async Task<IActionResult> Index()
    {
        ViewBag.BusinessCount = await db.BusinessProfiles.CountAsync();
        ViewBag.OpportunityCount = await db.FundingOpportunities.CountAsync(x => x.IsActive);
        ViewBag.ApplicationCount = await db.FundingApplications.CountAsync();
        ViewBag.RecentOpportunities = await db.FundingOpportunities
            .Where(x => x.IsActive).OrderBy(x => x.ClosingDate).Take(5).ToListAsync();
        return View();
    }
}
