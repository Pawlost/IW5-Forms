namespace FormsIW5.Api.DAL.Common.Entities;

public record FormEntity : EntityBase
{
    public required string FormName { get; set; } = "";
    public required DateTime FormStartDate { get; set; }
    public required DateTime FormEndDate { get; set; }
    public bool IsPublished { get; set; }
    public ICollection<QuestionEntity> Questions { get; set; } = [];
}
