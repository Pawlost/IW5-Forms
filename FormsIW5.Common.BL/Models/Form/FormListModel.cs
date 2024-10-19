using FormsIW5.Common.BL.Models.Interfaces;

namespace FormsIW5.Common.BL.Models.Form;

public record FormListModel : IModel
{
    public Guid Id { get; init; }
}
