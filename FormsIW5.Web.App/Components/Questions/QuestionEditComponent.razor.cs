using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionEditComponent
{
    private QuestionListModel Data { get; set; } = new();

    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    [Parameter]
    public Guid QuestionId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        Data = await QuestionFacade.ListAsync(QuestionId);
        await base.OnInitializedAsync();
    }

    public async Task UpdateAsync() {
        await QuestionFacade.QuestionPutAsync(Data);
    }

    private async Task HandleUpdateAsync(FocusEventArgs e)
    {
        await UpdateAsync();
    }
    public async Task AddQuestionOptionAsync() {
        var count = Data.AnswerSelections.Count;
        Data.AnswerSelections.Add(new() { SelectionName = $"Option {count}"});
        await UpdateAsync();
    }
}
