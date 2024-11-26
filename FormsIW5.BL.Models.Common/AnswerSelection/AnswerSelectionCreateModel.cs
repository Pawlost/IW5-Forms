using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.AnswerSelection;

public record AnswerSelectionCreateModel : ICreateModel
{
    public string? SelectionName { get; set; }
}
