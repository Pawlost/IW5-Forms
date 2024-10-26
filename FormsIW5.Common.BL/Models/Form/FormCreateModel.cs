using FormsIW5.Common.BL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.Form;

public record FormCreateModel : ICreateModel
{
    public string FormName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public Guid UserId { get; set; }
}
