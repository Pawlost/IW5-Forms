namespace FormsIW5.Api.DAL.Common.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; init; }
    public string? OwnerId { get; set; }
}
