using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Api.DAL.Common.Entities;

public record UserEntity : EntityBase
{
    [Required]
    public required string UserName { get; set; }
    public Uri? ProfilePicture { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public ICollection<FormEntity> Forms { get; set; } = [];
}
