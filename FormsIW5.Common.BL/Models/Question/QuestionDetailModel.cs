using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.Question;

public record QuestionDetailModel : IModel
{
    public Guid Id { get; init; }
    public string? TextAnswer { get; set; }
}
