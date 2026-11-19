using Microsoft.AspNetCore.Identity;

namespace FundConnect.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public string FullName { get; set; } = "";
}
