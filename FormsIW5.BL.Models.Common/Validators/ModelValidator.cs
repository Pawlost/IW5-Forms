using FluentValidation;
using FormsIW5.BL.Models.Common.Interfaces;

namespace FormsIW5.BL.Models.Common.Validators;

public class ModelValidator : AbstractValidator<IModel>
{
    public ModelValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
    }
}
