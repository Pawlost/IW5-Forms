using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages;

public partial class FormDetailPage
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

    private ICollection<QuestionListModel> questionList { get; set; } = [];

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        formDetail = await formFacade.FormGetAsync(Id);
        questionList = formDetail.Questions;
        await base.OnInitializedAsync();
    }

    public void Edit() 
    {
        navigationManager.NavigateTo($"/createForm/{formDetail.Id}");
    }
}
