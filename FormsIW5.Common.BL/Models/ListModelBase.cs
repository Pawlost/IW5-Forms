using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models;

public record ListModelBase : IModel
{
    public required Guid Id { get; set; }
}