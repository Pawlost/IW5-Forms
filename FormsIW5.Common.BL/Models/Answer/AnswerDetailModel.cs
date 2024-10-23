using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.Answer;

public record AnswerDetailModel : IModel
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }
    public Guid Id { get; init; }
}
