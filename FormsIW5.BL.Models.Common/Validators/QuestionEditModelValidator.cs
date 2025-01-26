using FluentValidation;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Common.Enums;

namespace FormsIW5.BL.Models.Common.Validators;

public class QuestionEditModelValidator : AbstractValidator<QuestionEditModel>
{
    public QuestionEditModelValidator() 
    {
        RuleFor(q => q.Id).NotEmpty();
        RuleFor(q => q.QuestionOptions)
            .Must(o => o != null && o.Count != 0)
            .When(o => o.QuestionType == QuestionType.Multiselection)
            .WithMessage("Options cannot be empty.");
        RuleFor(q => q.QuestionText).NotEmpty();

        RuleFor(q => q.QuestionType).IsInEnum();
        RuleFor(q => q.MinValue).NotEmpty().When(q => q.QuestionType == QuestionType.RangeType).WithMessage("Min range value must be set for range type");
        RuleFor(q => q.MaxValue).NotEmpty().GreaterThan(q => q.MinValue).When(q => q.QuestionType == QuestionType.RangeType).WithMessage("Max range value must be greater than min range value for range type");
    }
}
