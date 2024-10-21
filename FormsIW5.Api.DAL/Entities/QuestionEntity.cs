using FormsIW5.Common.Enums;

namespace FormsIW5.Api.DAL.Entities;

public record QuestionEntity : EntityBase
{
    public string? TextAnswer { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public QuestionType QuestionType { get; set; }
    public string? Description { get; set; }

    public Guid FormId { get; set; }
    public FormEntity? Form { get; set; }
}
