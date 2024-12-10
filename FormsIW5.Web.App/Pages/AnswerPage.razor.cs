using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages;

public partial class AnswerPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private QuestionFacade questionFacade { get; set; } = null!;

    [Inject]
    private AnswerFacade answerFacade { get; set; } = null!;

    private ICollection<AnswerDetailModel> Answers { get; set; } = [];

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Answers = await answerFacade.GetFormAnswersAsync(Id);
        await base.OnInitializedAsync();
    }
}
