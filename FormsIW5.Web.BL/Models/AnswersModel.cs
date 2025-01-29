using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Web.BL.Models;

public record AnswersModel
{
    public ICollection<AnswerDetailModel> Answers { get; set; } = [];
}
