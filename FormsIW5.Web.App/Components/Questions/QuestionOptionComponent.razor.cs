using FormsIW5.BL.Models.Common.AnswerSelection;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionOptionComponent
{
    [Parameter]
    public required QuestionOptionListModel QuestionOption { get; set; } 

    [Parameter]
    public required EventCallback OnChanged { get; set; }

    [Parameter]
    public required EventCallback<QuestionOptionListModel> OnDelete { get; set; }

    private async Task UpdateQuestionOptionAsync(FocusEventArgs e)
    {
        await OnChanged.InvokeAsync();
    }

    public async Task DeleteQuestionOptionAsync()
    {
        await OnDelete.InvokeAsync(QuestionOption);
    }
}
