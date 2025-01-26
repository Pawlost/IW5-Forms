using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.AnswerSelection;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Answers;

public partial class AnswersMultiselectionComponent
{
    [Parameter]
    public ICollection<QuestionOptionListModel> QuestionOptions { get; set; } = [];
    
    [Parameter]
    public Guid QuestionId { get; set; }

    public struct QuestionOptionId {
        public Guid QuestionId { get; set; }
        public Guid OptionId {get; set;}
    }

    [Parameter]
    public EventCallback<QuestionOptionId> OnSelected { get; set; }

    [Parameter]
    public Guid? InitialSelectedQuestionOption { get; set; } = null;

    private Guid SelectedQuestionOptionId { get; set; }

    protected override async Task OnInitializedAsync()
    {
        SelectedQuestionOptionId = InitialSelectedQuestionOption ?? Guid.Empty;
        await base.OnInitializedAsync();
    }

    private async Task OnQuestionOptionChange(Guid questionOptionId)
    {
        SelectedQuestionOptionId = questionOptionId;
        await OnSelected.InvokeAsync(new() { QuestionId = QuestionId, OptionId = questionOptionId });
    }
}
