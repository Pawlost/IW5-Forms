﻿using Microsoft.AspNetCore.Identity;

namespace FormsIW5.IdentityProvider.DAL.Entities;

public class AppUserEntity : IdentityUser<Guid>
{
    public bool Active { get; set; }
    public string Subject { get; set; }
    public string? ProfilePictureUrl { get; set; }
}
