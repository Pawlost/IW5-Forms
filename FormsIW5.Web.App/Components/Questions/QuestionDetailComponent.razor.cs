using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionDetailComponent
{
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    private QuestionDetailModel QuestionModel { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        QuestionModel = await QuestionFacade.GetQuestionDetailAsync(Id);
        await base.OnInitializedAsync();
    }
    public void Back()
    {
        navigationManager.NavigateTo($"/questions/search/{Id}");
    }

    public void Redirect()
    {
        navigationManager.NavigateTo($"/question/{Id}");
    }
}
