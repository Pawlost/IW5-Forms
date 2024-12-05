using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.IdentityProvider.DAL.Seeds;

public static class ClaimSeeds
{
    public static readonly AppUserClaimEntity AdminClaim = new()
    {
        Id = -1,
        UserId = UserSeeds.AdminUser.Id,
        ClaimType = "role",
        ClaimValue = "admin"
    };

    public static void Seed(this ModelBuilder modelBuilder) =>
        modelBuilder.Entity<AppUserClaimEntity>().HasData(AdminClaim);
}
