using System.Collections.Generic;
using Blazored.FluentValidation;
using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;
using static FormsIW5.Web.App.Components.Answers.AnswersMultiselectionComponent;

namespace FormsIW5.Web.App.Components.Answers;

public partial class QuestionAnswersListComponent
{

    [Parameter]
    public ICollection<QuestionListModel> Questions { get; set; } = [];

    [Inject]
    private AnswerFacade AnswerFacade { get; set; } = null!;

    private enum AnswerState
    {
        NoChange,
        Updated,
        Submitted
    };

    private AnswerState answerState = AnswerState.Submitted;
    private AnswerState AnswerStatus { get; set; } = AnswerState.NoChange;

    private ICollection<AnswerDetailModel> Answers { get; set; } = [];

    private FluentValidationValidator? validator;

    protected override async Task OnParametersSetAsync()
    {
        Answers.Clear();
        foreach (var question in Questions)
        {
            AnswerDetailModel adm;
            if (await AnswerFacade.GetHasUserAnsweredAsync(question.Id))
            {
                adm = await AnswerFacade.GetUserAnswerAsync(question.Id);
            }
            else {
                adm = new AnswerDetailModel()
                {
                    Id = Guid.NewGuid(),
                    QuestionId = question.Id
                };
            }

            adm.Question = question;
            Answers.Add(adm);
        }

        await base.OnParametersSetAsync();
    }

    private async Task SubmitAnswerAsync()
    {
        foreach (var answer in Answers)
        {
            await AnswerFacade.PutAnswerAsync(answer);
            AnswerStatus = answerState;
        }
    }

    public void OnQuestionOptionMultiselection(QuestionOptionId selectedIds)
    {
        var answer = Answers.Single(f => f.Question.Id == selectedIds.QuestionId);
        if (answer is not null)
        {
            answer.QuestionOptionId = selectedIds.OptionId;
        }
    }
}
