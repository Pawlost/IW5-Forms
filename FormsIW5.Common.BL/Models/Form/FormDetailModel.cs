using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Common.BL.Models.Form;

public record FormDetailModel : IModel
{
    public Guid Id { get; init; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public ICollection<QuestionListModel> Questions { get; set; } = [];
}
