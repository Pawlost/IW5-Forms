using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Common.Enums;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Answers;

public partial class AnswerComponent
{
    [Parameter]
    public required QuestionEditModel Question { get; set; }

    private AnswerCreateModel Data { get; set; } = new();

    [Inject]
    private AnswerFacade answerFacade { get; set; } = null!;

    public void HandleChange(ChangeEventArgs e)
    {
        Data.TextAnswer = e.Value?.ToString() ?? "";
    }

    public async Task SubmitAnswerAsync()
    {
        Data.QuestionId = Question.Id;
        await answerFacade.AnswerPostAsync(Data);
    }
}
