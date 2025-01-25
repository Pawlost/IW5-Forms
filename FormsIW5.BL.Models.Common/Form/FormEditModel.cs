using System.ComponentModel.DataAnnotations;
using FormsIW5.BL.Models.Common.Interfaces;
namespace FormsIW5.BL.Models.Common.Form;

public record FormEditModel : FormCreateModel, IModel
{
    [Required]
    public required Guid Id { get; init; }
    public static new FormEditModel Empty => new()
    {
        Id = Guid.NewGuid(),
        FormName = string.Empty,
        FormStartDate = DateTime.Now,
        FormEndDate = DateTime.Now.AddDays(1),
        IsPublished = false
    };
}
