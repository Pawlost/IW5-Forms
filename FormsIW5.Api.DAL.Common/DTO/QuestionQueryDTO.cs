namespace FormsIW5.Api.DAL.Common.DTO;

public record QuestionQueryDTO
{
    public string? TextMatch { get; set; }
    public required Guid FormId { get; set; }
}
