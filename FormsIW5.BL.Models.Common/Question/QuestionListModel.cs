using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace FormsIW5.BL.Models.Common.Question;

public class QuestionListModel
{
    public Guid Id { get; init; }
    public string? QuestionText { get; set; }
    public string? Description { get; set; }

    [Required]
    public Guid FormId { get; set; }
}
