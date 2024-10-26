using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Common.BL.Models.AnswerSelection;

public record AnswerSelectionDetailModel : IModel
{
    public Guid Id { get; init; }
    public string? SelectionName { get; set; }
    public AnswerSelectionListModel? SelectedAnswer { get; set; }
    public required QuestionListModel Question { get; set; }
}
