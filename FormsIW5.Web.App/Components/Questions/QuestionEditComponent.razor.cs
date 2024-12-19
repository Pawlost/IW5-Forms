using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Questions;

public partial class QuestionEditComponent
{
    [Parameter]
    public required EventCallback<Guid> OnDelete { get; set; }

    [Parameter]
    public Guid QuestionId { get; set; }

    private QuestionEditModel Model { get; set; } = new();

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    [Inject]
    private QuestionOptionFacade QuestionOptionFacade { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Model = await QuestionFacade.ListAsync(QuestionId);
        await base.OnInitializedAsync();
    }

    public async Task UpdateAsync() {
        await QuestionFacade.QuestionPutAsync(Model);
        Model = await QuestionFacade.ListAsync(QuestionId);
    }

    public async Task AddQuestionOptionAsync() 
    {
        var count = Model.QuestionOptions.Count;
        Model.QuestionOptions.Add(new() { QuestionOptionName = $"Option {count}"});
        await UpdateAsync();
    }

    public async Task DeleteQuestionOptionAsync(QuestionOptionListModel model)
    {
        Model.QuestionOptions.Remove(model);
        await QuestionOptionFacade.QuestionOptionDeleteAsync(model.Id);
        StateHasChanged();
    }

    public async Task DeleteQuestionAsync()
    {
        await QuestionFacade.QuestionDeleteAsync(QuestionId);
        await OnDelete.InvokeAsync(QuestionId);
    }
}
