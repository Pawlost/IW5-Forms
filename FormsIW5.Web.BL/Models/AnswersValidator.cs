using FluentValidation;
using FormsIW5.BL.Models.Common.Validators;

namespace FormsIW5.Web.BL.Models
{
    public class AnswersValidator : AbstractValidator<AnswersModel>
    {
        public AnswersValidator()
        {
            RuleForEach(a => a.Answers).SetValidator(new AnswerModelValidator());
        }
    }
}
