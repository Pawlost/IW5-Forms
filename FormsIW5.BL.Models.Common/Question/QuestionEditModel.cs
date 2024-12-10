using System.ComponentModel.DataAnnotations;
using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.Common.Enums;

namespace FormsIW5.BL.Models.Common.Question;

public record QuestionEditModel : IModel
{
    public Guid Id { get; init; }
    public string? QuestionText { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public string? Description { get; set; }

    [Required]
    public Guid FormId { get; set; }

    public QuestionType QuestionType { get; set; }
    public ICollection<QuestionOptionListModel> QuestionOptions { get; set; } = [];
}
