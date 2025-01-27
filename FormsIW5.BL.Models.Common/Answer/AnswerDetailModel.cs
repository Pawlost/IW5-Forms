using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.BL.Models.Common.Question;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Answer;

public record AnswerDetailModel : IModel
{
    public Guid Id { get; init; }
    public string TextAnswer { get; set; } = "";
    public int? IntegerAnswer { get; set; }

    [Required]
    public Guid QuestionId { get; set; }

    [Required]
    public QuestionListModel Question { get; set; } = new();

    public Guid? QuestionOptionId { get; set; }
}
