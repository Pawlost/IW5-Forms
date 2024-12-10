using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.Answer;

public record AnswerListModel : IModel
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }
    public QuestionOptionListModel? SelectedAnswer { get; set; }
    public Guid Id { get; init; }
}
