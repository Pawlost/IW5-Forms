using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Questions;

public partial class QuestionDetailPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;
    private QuestionDetailModel QuestionDetailModel { get; set; } = new();
    protected override async Task OnInitializedAsync()
    {
        QuestionDetailModel = await QuestionFacade.QuestionGetAsync(Id);
        await base.OnInitializedAsync();
    }
}
