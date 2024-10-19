using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.Form;

public record QuestionListModel : IModel
{
    public Guid Id { get; init; }
    public string? TextAnswer { get; set; }
}
