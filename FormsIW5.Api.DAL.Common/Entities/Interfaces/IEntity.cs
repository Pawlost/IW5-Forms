namespace FormsIW5.Api.DAL.Common.Entities.Interfaces;

public interface IEntity
{
    Guid Id { get; init; }
    string? OwnerId { get; set; }
}
