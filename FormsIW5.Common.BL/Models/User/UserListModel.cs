using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.User;

public record UserListModel : ListModelBase
{
    [Required]
    public required string UserName { get; set; }
}
