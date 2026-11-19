using FundConnect.Application.Matching;
using FundConnect.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FundConnect.Web.Controllers;

public class FundingController(FundConnectDbContext db, FundingMatcher matcher) : Controller
{
    public async Task<IActionResult> Index(string? search)
    {
        var query = db.FundingOpportunities.Where(x => x.IsActive && x.ClosingDate >= DateTime.UtcNow);
        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(x => x.Title.Contains(search) || x.Provider.Contains(search) || x.Industry.Contains(search));
        ViewBag.Search = search;
        return View(await query.OrderBy(x => x.ClosingDate).ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var item = await db.FundingOpportunities.FirstOrDefaultAsync(x => x.Id == id && x.IsActive);
        return item is null ? NotFound() : View(item);
    }
}
