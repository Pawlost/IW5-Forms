﻿using Blazored.FluentValidation;
using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;
public partial class FormEditComponent
{
    [Inject]
    private NavigationManager navigationManager { get; set; } = null!;

    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    [Parameter]
    public required Guid FormId { get; set; }

    public ICollection<Guid> QuestionsIds { get; set; } = [];

    private FormEditModel EditForm { get; set; } = FormEditModel.Empty;
    private bool IsUpdated { get; set; }


    private FluentValidationValidator? validator;

    private async Task CheckValidationAsync()
    {
        if (validator != null)
        {
            var isValid = await validator.ValidateAsync();
            if (isValid)
            {
                await SaveAsync();
            }
        }
    }

    public async Task SaveAsync()
    {
        var guid = await FormFacade.FormEditAsync(EditForm);
        IsUpdated = guid is not null;
    }

    protected override async Task OnInitializedAsync()
    {
        EditForm = await FormFacade.GetEditAsync(FormId);
        QuestionsIds = await QuestionFacade.GetQuestionsIdsAsync(FormId);
        await base.OnInitializedAsync();
    }
    public async Task AddQuestionAsync()
    {
        var draftQuestion = QuestionCreateModel.Empty;
        draftQuestion.QuestionText = "Draft question";
        draftQuestion.FormId = FormId;

        var questionId = await QuestionFacade.QuestionPostAsync(draftQuestion);
        QuestionsIds.Add(questionId);
    }

    public void DeleteQuestionCallback(Guid questionId){
        QuestionsIds.Remove(questionId);
        StateHasChanged();
    }

    public void Back()
    {
        navigationManager.NavigateTo($"/forms/{FormId}");
    }
}
