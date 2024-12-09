using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.AnswerSelection;

public record QuestionOptionCreateModel : ICreateModel
{
    public string? SelectionName { get; set; }
}
