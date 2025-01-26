using FluentValidation;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.BL.Models.Common.Validators;

public abstract class QuestionCreateModelValidatorBase<T> : AbstractValidator<T> where T : QuestionCreateModel
{
    public QuestionCreateModelValidatorBase() : base()
    {
    }
}
