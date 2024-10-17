using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.User;

public record UserDetailModel : DetailModelBase
{
    [Required]
    public required string UserName { get; set; }
}
