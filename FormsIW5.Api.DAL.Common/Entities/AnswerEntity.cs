namespace FormsIW5.Api.DAL.Common.Entities;

public record AnswerEntity : EntityBase
{
    public string? TextAnswer { get; set; }
    public int? IntegerAnswer { get; set; }
    public Guid QuestionId { get; set; }
    public QuestionEntity? Question { get; set; }
    public Guid? SelectedAnswerId { get; set; }
    public QuestionOptionEntity? SelectedAnswer { get; set; }
}
