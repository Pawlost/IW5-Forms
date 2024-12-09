namespace FormsIW5.Api.DAL.Common.Entities;

public record QuestionOptionEntity : EntityBase
{
    public required string SelectionName { get; set; }
    public Guid QuestionId { get; set; }
    public QuestionEntity? Question { get; set; }
}
