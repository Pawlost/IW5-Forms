using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.Enums;

namespace FormsIW5.Common.BL.Models.Question;

public record QuestionListModel : IModel
{
    public Guid Id { get; init; }
    public string? QuestionText { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public QuestionType QuestionType { get; set; }
}
