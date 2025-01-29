using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.User;
public class AppUserCreateModel
{
    [Required]
    public string UserName { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;
    public string? Subject { get; set; }
    public string? Email { get; set; }
    public string? GivenName { get; set; }
    public string? FamilyName { get; set; }
}
