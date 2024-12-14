using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormDetailPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private FormFacade formFacade { get; set; } = null!;

    private FormDetailModel formDetail { get; set; } = null!;

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private AnswerFacade AnswerFacade { get; set; } = null!;

    private enum AnswerState { 
        NoChange,
        Updated,
        Submitted
    };

    private AnswerState answerState = AnswerState.Submitted;
    private AnswerState AnswerStatus { get; set; } = AnswerState.NoChange;

    protected override async Task OnInitializedAsync()
    {
        formDetail = await formFacade.GetDetailAsync(Id);
        foreach (var question in formDetail.Questions) {
            if (question.Answer == null) {
                question.Answer = new() { Id=Guid.NewGuid(), QuestionId = question.Id };
            } 
            else
            {
                answerState = AnswerState.Updated;
            }
        }

        await base.OnInitializedAsync();
    }

    public void Edit()
    {
        navigationManager.NavigateTo($"/createForm/{formDetail.Id}");
    }
    public void ShowAnswers()
    {
        navigationManager.NavigateTo($"/searchQuestions/{formDetail.Id}");
    }

    private async Task SubmitAnswerAsync() 
    {
        foreach (var model in formDetail.Questions) 
        {
            if (model.Answer != null)
            {
                await AnswerFacade.AnswerPutAsync(model.Answer);
                AnswerStatus = answerState;
            }
        }
    }

    public void HandleOptionChange(ChangeEventArgs e)
    {
        //Data.TextAnswer = e.Value?.ToString() ?? "";
    }
}
