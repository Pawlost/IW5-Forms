using FormsIW5.Common.BL.Models.Interfaces;
using FormsIW5.Common.BL.Models.Question;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.Common.BL.Models.Form;

public record FormDetailModel : IModel
{
    public Guid Id { get; init; }
    public string FormName { get; set; } = "";
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    [Required]
    public Guid UserId { get; set; }
    public ICollection<QuestionListModel> Questions { get; set; } = [];
}
