using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.AnswerSelection;

public record QuestionOptionListModel : IModel
{
    public Guid Id { get; init; }
    public required string SelectionName { get; set; }
}
