using FundConnect.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;

namespace FundConnect.Web;

public static class SeedData
{
    public static async Task InitializeAsync(IServiceProvider services)
    {
        var roles = new[] { "BusinessOwner", "FundingAdministrator", "SystemAdministrator" };
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        foreach (var role in roles)
            if (!await roleManager.RoleExistsAsync(role))
                await roleManager.CreateAsync(new IdentityRole(role));
    }
}
