using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;
public partial class FormCreateComponent
{
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    [Parameter]
    public required Guid FormId { get; set; }

    public ICollection<Guid> QuestionsIds { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        QuestionsIds = await QuestionFacade.GetQuestionsIdsAsync(FormId);
        await base.OnInitializedAsync();
    }
    public async Task AddQuestionAsync()
    {
        var draftQuestion = new QuestionCreateModel() { QuestionText = "Draft question", FormId = FormId };
        var questionId = await QuestionFacade.QuestionPostAsync(draftQuestion);
        QuestionsIds.Add(questionId);
    }

    public void Back()
    {
        navigationManager.NavigateTo($"/forms/create");
    }
}
