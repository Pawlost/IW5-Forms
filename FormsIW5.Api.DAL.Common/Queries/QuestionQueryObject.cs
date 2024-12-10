namespace FormsIW5.Api.DAL.Common.Queries;

public record QuestionQueryObject
{
    public string? TextMatch { get; set; }
    public required Guid FormId { get; set; }
}
