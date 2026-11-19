using FundConnect.Domain.Entities;
using FundConnect.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FundConnect.Web.Controllers;

[Authorize(Roles = "BusinessOwner")]
public class BusinessController(FundConnectDbContext db) : Controller
{
    [HttpGet]
    public IActionResult Create() => View(new BusinessProfile());

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(BusinessProfile model)
    {
        ModelState.Remove(nameof(model.OwnerUserId));
        if (!ModelState.IsValid) return View(model);

        model.OwnerUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
        model.CreatedAtUtc = DateTime.UtcNow;
        db.BusinessProfiles.Add(model);
        await db.SaveChangesAsync();
        TempData["Success"] = "Your business profile has been saved.";
        return RedirectToAction("Index", "Dashboard");
    }
}
