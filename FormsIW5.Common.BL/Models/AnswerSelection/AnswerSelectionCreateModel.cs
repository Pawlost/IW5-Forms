using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.AnswerSelection;

public record AnswerSelectionCreateModel : ICreateModel
{
    public string? SelectionName { get; set; }
}
