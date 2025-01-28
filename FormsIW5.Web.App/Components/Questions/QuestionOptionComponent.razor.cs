using Blazored.FluentValidation;
using FormsIW5.BL.Models.Common.AnswerSelection;
using Microsoft.AspNetCore.Components;
namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionOptionComponent
{
    [Parameter]
    public required QuestionOptionListModel QuestionOption { get; set; } 

    [Parameter]
    public required EventCallback OnChanged { get; set; }

    [Parameter]
    public required EventCallback<QuestionOptionListModel> OnDelete { get; set; }

    private FluentValidationValidator? validator;

    private async Task CheckValidationAsync()
    {
        if (validator != null)
        {
            var isValid = await validator.ValidateAsync();
            if (isValid)
            {
                await UpdateQuestionOptionAsync();
            }
        }
    }

    private async Task UpdateQuestionOptionAsync()
    {
        await OnChanged.InvokeAsync();
    }

    public async Task DeleteQuestionOptionAsync()
    {
        await OnDelete.InvokeAsync(QuestionOption);
    }
}
