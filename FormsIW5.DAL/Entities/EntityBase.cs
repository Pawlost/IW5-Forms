using FormsIW5.DAL.Entities.Interfaces;

namespace FormsIW5.DAL.Entities
{
    public abstract record EntityBase : IEntity
    {
        public required Guid Id { get; init; }
    }
}
