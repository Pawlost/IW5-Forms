using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.AnswerSelection;
using FormsIW5.Common.Enums;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Answers;

public partial class AnswersComponent
{
    [Parameter]
    public ICollection<QuestionOptionListModel> QuestionOptions { get; set; } = [];

    [Parameter]
    public QuestionType QuestionType { get; set; } 

    [Parameter]
    public ICollection<AnswerDetailModel> AnswerModels { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
    }
}
