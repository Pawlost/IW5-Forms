namespace FormsIW5.Api.DAL.Common.Queries;

public record QuestionQueryObject
{
    public string? Text { get; set; }
    public string? Description { get; set; }
    public required Guid FormId { get; set; }
}
