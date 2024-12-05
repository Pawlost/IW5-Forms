namespace FormsIW5.Api.DAL.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; init; }
    public string? OwnerId { get; init; }
}
