using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.AnswerSelection;

public record AnswerSelectionListModel : IModel
{
    public Guid Id { get; init; }
    public string? SelectionName { get; set; }
}
