using FormsIW5.BL.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Form;

public record FormCreateModel : ICreateModel
{
    [Required]
    public required string FormName { get; set; }

    [Required]
    public required DateTime FormStartDate { get; set; }

    [Required]
    public required DateTime FormEndDate { get; set; }

    public bool IsPublished { get; set; } = false;

    public static FormCreateModel Empty => new()
    {
        FormName = string.Empty,
        FormStartDate = DateTime.Now,
        FormEndDate = DateTime.Now.AddDays(1),
        IsPublished = false
    };
}
