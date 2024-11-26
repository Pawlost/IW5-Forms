using FormsIW5.BL.Models.Common.Interfaces;
using FormsIW5.BL.Models.Common.Question;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Form;

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
