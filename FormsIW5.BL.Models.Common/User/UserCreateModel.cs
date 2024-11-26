using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.User;

public record UserCreateModel : ICreateModel
{
    [Required]
    public required string UserName { get; set; }
    public Uri? ProfilePicture { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
}
