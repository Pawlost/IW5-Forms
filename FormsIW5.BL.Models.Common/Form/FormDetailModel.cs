using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.BL.Models.Common.Form;

public record FormDetailModel : IModel
{
    public Guid Id { get; init; }
    public string FormName { get; set; } = "";
    public DateTime FormStartDate { get; set; }
    public DateTime FormEndDate { get; set; }
    public bool IsOwner { get; set; }
    public ICollection<QuestionListModel> Questions { get; set; } = [];
}
