using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Web.App.Options;

public class ClientUrlOptions
{
    [Required]
    public required string BaseApi { get; set; }


    [Required]
    public required string UserManager { get; set; }
}
