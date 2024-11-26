using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.AnswerSelection;

public record AnswerSelectionListModel : IModel
{
    public Guid Id { get; init; }
    public string? SelectionName { get; set; }
}
