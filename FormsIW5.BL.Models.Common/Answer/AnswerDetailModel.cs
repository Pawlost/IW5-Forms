using FormsIW5.BL.Models.Common.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Answer;

public record AnswerDetailModel : IModel
{
    public Guid Id { get; init; }
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }

    [Required]
    public Guid QuestionId { get; set; }

    public Guid QuestionOptionId { get; set; }
}
