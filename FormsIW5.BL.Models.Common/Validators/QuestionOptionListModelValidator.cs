using FluentValidation;
using FormsIW5.BL.Models.Common.AnswerSelection;

namespace FormsIW5.BL.Models.Common.Validators;

public class QuestionOptionListModelValidator : AbstractValidator<QuestionOptionListModel>
{
    public QuestionOptionListModelValidator()
    {
        RuleFor(q => q.QuestionOptionName).NotEmpty();
    }
}
