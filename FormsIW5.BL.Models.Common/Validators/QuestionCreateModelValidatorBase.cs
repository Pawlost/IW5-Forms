using FluentValidation;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Common.Enums;

namespace FormsIW5.BL.Models.Common.Validators;

public class QuestionCreateModelValidator : QuestionCreateModelValidatorBase<QuestionCreateModel>
{
    public QuestionCreateModelValidator() : base()
    {
    }
}
