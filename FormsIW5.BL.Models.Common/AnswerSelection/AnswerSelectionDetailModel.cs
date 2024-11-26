using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.BL.Models.Common.AnswerSelection;

public record AnswerSelectionDetailModel : IModel
{
    public Guid Id { get; init; }
    public string? SelectionName { get; set; }
    public AnswerSelectionListModel? SelectedAnswer { get; set; }
    public required QuestionListModel Question { get; set; }
}
