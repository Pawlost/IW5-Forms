using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionCard
{
    [Parameter]
    public QuestionListModel QuestionListModel { get; set; } = new();
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    public void Redirect()
    {
        navigationManager.NavigateTo($"/question/{QuestionListModel.Id}");
    }

}
