using FluentValidation;
using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.BL.Models.Common.Validators;

public class FormCreateModelValidator : AbstractValidator<FormCreateModel>
{
    public FormCreateModelValidator()
    {
        RuleFor(x => x.FormName).NotEmpty();
        RuleFor(x => x.FormStartDate).NotEmpty();
        RuleFor(x => x.FormEndDate).NotEmpty().GreaterThan(x => x.FormStartDate).WithMessage("End date must be larger than start date");
    }
}
