namespace FormsIW5.Api.DAL.Common.Entities;

public record FormEntity : EntityBase
{
    public string FormName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Guid UserId { get; set; }
    public UserEntity? User { get; set; }

    public ICollection<QuestionEntity> Questions { get; set; } = [];
}
