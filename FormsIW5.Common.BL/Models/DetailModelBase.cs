using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models;

public record DetailModelBase : IModel
{
    public required Guid Id { get; set; }
}
