using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages;

public partial class QuestionsListPage
{
    [Inject]
    private QuestionFacade facade { get; set; } = null!;

    private ICollection<QuestionEditModel> questionList { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        questionList = await facade.QuestionListGetAsync();
        await base.OnInitializedAsync();
    }
}
