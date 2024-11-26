using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.Form;

public record FormListModel : IModel
{
    public Guid Id { get; init; }
    public string FormName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}
