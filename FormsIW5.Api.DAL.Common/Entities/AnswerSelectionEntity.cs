namespace FormsIW5.Api.DAL.Common.Entities;

public record AnswerSelectionEntity : EntityBase
{
    public string? SelectionName { get; set; }
    public Guid QuestionId { get; set; }
    public QuestionEntity? Question { get; set; }
    public ICollection<AnswerEntity> Answers { get; set; } = [];
}
