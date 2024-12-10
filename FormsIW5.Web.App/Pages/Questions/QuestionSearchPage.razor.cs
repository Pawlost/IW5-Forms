using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages.Questions;

public partial class QuestionSearchPage
{
    [Parameter]
    public Guid Id { get; set; }

    [Inject]
    private QuestionFacade questionFacade { get; set; } = null!;

    private ICollection<QuestionListModel> Questions { get; set; } = [];

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    public string SearchText { get; set; } = "";
    public string SearchDescription { get; set; } = "";

    protected override async Task OnInitializedAsync()
    {
        Questions = await questionFacade.SearchByTextAsync(Id, "");
        await base.OnInitializedAsync();
    }
    public async Task PerformSearchByDescriptionAsync()
    {
        Questions = await questionFacade.SearchByDescriptionAsync(Id, SearchDescription);
    }

    public async Task PerformSearchByTextAsync() 
    {
        Questions = await questionFacade.SearchByTextAsync(Id, SearchText);
    }
}
