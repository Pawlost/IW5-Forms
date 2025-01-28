using FormsIW5.Common.Enums;

namespace FormsIW5.Api.DAL.Common.Entities;

public record QuestionEntity : EntityBase
{
    public string? QuestionText { get; set; }
    public string? Description { get; set; }
    public int MinValue { get; set; }
    public int MaxValue { get; set; }
    public bool IsRequired { get; set; }
    public QuestionType QuestionType { get; set; }
    public Guid FormId { get; set; }
    public FormEntity? Form { get; set; }
    public ICollection<AnswerEntity> Answers { get; set; } = [];
    public ICollection<QuestionOptionEntity> QuestionOptions { get; set; } = [];
}
