using FormsIW5.Common.Enums;

namespace FormsIW5.Api.DAL.Common.Entities;

public record QuestionEntity : EntityBase
{
    public string? QuestionText { get; set; }
    public string? Description { get; set; }
    public int FromValue { get; set; }
    public int ToValue { get; set; }
    public QuestionType QuestionType { get; set; }
    public Guid FormId { get; set; }
    public FormEntity? Form { get; set; }
    public ICollection<AnswerEntity> Answers { get; set; } = [];
    public ICollection<QuestionOptionEntity> AnswerSelections { get; set; } = [];
}
