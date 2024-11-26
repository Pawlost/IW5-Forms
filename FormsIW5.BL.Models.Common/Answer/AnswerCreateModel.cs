using FormsIW5.Common.BL.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Models.Answer;

public record AnswerCreateModel : ICreateModel
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }

    public Guid? SelectedAnswerId { get; set; }

    [Required]
    public Guid QuestionId { get; set; }
}
