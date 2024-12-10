using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.App.Components.Answers;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Forms;

public partial class FormAnswerPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private QuestionFacade questionFacade { get; set; } = null!;

    [Inject]
    private AnswerFacade answerFacade { get; set; } = null!;

    [Inject]
    private FormFacade formFacade { get; set; } = null!;

    private FormDetailModel formDetail { get; set; } = null!;

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        formDetail = await formFacade.FormGetAsync(Id);
        await base.OnInitializedAsync();
    }

    public void Edit()
    {
        navigationManager.NavigateTo($"/createForm/{formDetail.Id}");
    }

    public void Answer()
    {
        navigationManager.NavigateTo($"/answerForm/{formDetail.Id}");
    }
}
