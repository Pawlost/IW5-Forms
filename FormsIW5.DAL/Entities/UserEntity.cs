using FormsIW5.DAL.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.DAL.Entities;

public record UserEntity : EntityBase
{
    [Required]
    public required string UserName { get; set; }
    public Uri? ProfilePicture { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public ICollection<FormEntity> Forms { get; set; } = [];
}
