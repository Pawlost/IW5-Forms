using System.ComponentModel.DataAnnotations;
using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.Question;

public record QuestionEditModel : QuestionCreateModel, IModel
{
    [Required]
    public required Guid Id { get; init; }
    public ICollection<QuestionOptionListModel> QuestionOptions { get; set; } = [];
}
