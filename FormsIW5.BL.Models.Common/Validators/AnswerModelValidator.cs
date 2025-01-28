using FluentValidation;
using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.Common.Enums;

namespace FormsIW5.BL.Models.Common.Validators;

public class AnswerModelValidator : AbstractValidator<AnswerDetailModel>
{
    public AnswerModelValidator()
    {
        RuleFor(q => q.TextAnswer).NotEmpty().When(q => q.Question.QuestionType == QuestionType.TextType);
        RuleFor(q => q.IntegerAnswer).Must((m, i) => i >= m.Question.MinValue && i <= m.Question.MaxValue).When(q => q.Question.QuestionType == QuestionType.RangeType);
        RuleFor(q => q.QuestionOptionId).Must((m, id) => m.Question.QuestionOptions.Any(qo => qo.Id == id)).When(q => q.Question.QuestionType == QuestionType.Multiselection);
    }
}
