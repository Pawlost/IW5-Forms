using FormsIW5.IdentityProvider.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.IdentityProvider.DAL.Seeds
{
    public static class UserSeeds
    {
        public static readonly AppUserEntity AdminUser = new()
        {
            Id = Guid.Parse("b1f70862-ba5c-45cd-9086-b99347db2ee8"),
            UserName = "Admin",
            Subject = "admin",
            NormalizedUserName = "ADMIN",
            Email = "xbalus03@vutbr.cz",
            NormalizedEmail = "XBALUS03@VUTBR.CZ",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAIAAYagAAAAEI14r3DlK6kMbyvIA1cf0/eFzpY8nbdDqwsTXeTEYgQZhG1XeS7hZLHrZWFmNnGCwQ==",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = false
        };

        public static readonly AppUserEntity TestUser = new()
        {
            Id = Guid.Parse("94aafab9-26f0-49ac-a5de-c98709057238"),
            UserName = "User",
            Subject = "user",
            NormalizedUserName = "USER",
            Email = "xbalus03@vutbr.cz",
            NormalizedEmail = "XBALUS03@VUTBR.CZ",
            EmailConfirmed = false,
            PasswordHash = "AQAAAAIAAYagAAAAEI14r3DlK6kMbyvIA1cf0/eFzpY8nbdDqwsTXeTEYgQZhG1XeS7hZLHrZWFmNnGCwQ==",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            LockoutEnabled = false
        };

         public static void Seed(this ModelBuilder modelBuilder) =>
                    modelBuilder.Entity<AppUserEntity>().HasData(AdminUser, TestUser);
    }
}
