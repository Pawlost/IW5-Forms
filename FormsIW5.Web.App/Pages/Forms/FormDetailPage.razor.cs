using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using static FormsIW5.Web.App.Components.Answers.AnswersMultiselectionComponent;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormDetailPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private FormFacade formFacade { get; set; } = null!;

    private FormDetailModel FormModel { get; set; } = new();

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private AnswerFacade AnswerFacade { get; set; } = null!;

    [CascadingParameter]
    private Task<AuthenticationState> authStateTask { get; set; } = null!;

    private enum AnswerState { 
        NoChange,
        Updated,
        Submitted
    };

    private AnswerState answerState = AnswerState.Submitted;
    private AnswerState AnswerStatus { get; set; } = AnswerState.NoChange;

    protected override async Task OnInitializedAsync()
    {
        var authState = await authStateTask;
        string clientName = authState.User?.Identity?.IsAuthenticated is true ? clientName = ClientNames.LogInApiClientName : clientName = ClientNames.AnonymousClientName;

        FormModel = await formFacade.GetDetailAsync(Id, clientName);

        foreach (var question in FormModel.Questions)
        {
            if (question.Answer == null)
            {
                question.Answer = new() { Id = Guid.NewGuid(), QuestionId = question.Id };
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
        navigationManager.NavigateTo($"/forms/create/{FormModel.Id}");
    }
    public void ShowAnswers()
    {
        navigationManager.NavigateTo($"/questions/search/{FormModel.Id}");
    }
    public void Back()
    {
        navigationManager.NavigateTo($"/");
    }

    private async Task SubmitAnswerAsync() 
    {
        foreach (var model in FormModel.Questions) 
        {
            if (model.Answer != null)
            {
                await AnswerFacade.AnswerPutAsync(model.Answer);
                AnswerStatus = answerState;
            }
        }
    }

    public async Task DeleteAsync() {
        await formFacade.FormDeleteAsync(Id);
        Back();
    }

    public void OnQuestionOptionMultiselection(QuestionOptionId selectedIds)
    {
        var question = FormModel.Questions.Single(f => f.Id == selectedIds.QuestionId);
        if (question.Answer is not null)
        {
            question.Answer.QuestionOptionId = selectedIds.OptionId;
        }
    }
}
