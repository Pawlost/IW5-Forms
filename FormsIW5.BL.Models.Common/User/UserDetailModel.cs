using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.User;

public record UserDetailModel : IModel
{
    public Guid Id { get; init; }

    [Required]
    public required string UserName { get; set; }
    public Uri? ProfilePicture { get; set; }
    public UserRole Role { get; set; } = UserRole.User;
    public ICollection<FormListModel> Forms { get; set; } = [];
}
