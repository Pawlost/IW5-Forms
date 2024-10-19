using FormsIW5.Common.BL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.User;

public record UserDetailModel : IModel
{
    public Guid Id { get; init; }

    [Required]
    public required string UserName { get; set; }
}
