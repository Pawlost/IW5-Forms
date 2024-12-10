using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FormsIW5.Web.App.Components.Answers;

public partial class AnswerComponent
{
    [Parameter]
    public required QuestionListModel Question { get; set; }

    private AnswerCreateModel Data { get; set; } = new();

    [Inject]
    private AnswerFacade answerFacade { get; set; } = null!;

    protected override async Task OnInitializedAsync()
    {
        Data = new() { TextAnswer = "lmao", IntegerAnswer = 0 };
        await base.OnInitializedAsync();
    }

    public async Task SubmitAnswerAsync() {
        Data.QuestionId = Question.Id;
        await answerFacade.AnswerPostAsync(Data);
    }
}
