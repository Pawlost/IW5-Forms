using FormsIW5.Api.DAL.Entities.Interfaces;

namespace FormsIW5.Api.DAL.Entities;

public abstract record EntityBase : IEntity
{
    public required Guid Id { get; init; }
}
