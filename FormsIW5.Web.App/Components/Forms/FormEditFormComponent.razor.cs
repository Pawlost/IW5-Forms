using FormsIW5.BL.Models.Common.Form;
using FormsIW5.BL.Models.Common.Question;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components.Forms;

public partial class FormEditFormComponent
{
    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Inject]
    private QuestionFacade QuestionFacade { get; set; } = null!;

    [Parameter]
    public required Guid FormId { get; set; }

    private FormDetailModel Data { get; set; } = new();

    public ICollection<Guid> QuestionIds { get; set; } = [];

    protected override async Task OnInitializedAsync()
    {
        Data = await FormFacade.FormGetAsync(FormId);
        QuestionIds = Data.Questions.Select(d => d.Id).ToList();
        await base.OnInitializedAsync();
    }
    public async Task AddQuestionAsync()
    {
        var draftQuestion = new QuestionCreateModel() { QuestionText = "Draft question", FormId = Data.Id };
        var questionId = await QuestionFacade.QuestionPostAsync(draftQuestion);
        QuestionIds.Add(questionId);
    }

    public async Task SaveAsync()
    {
        await FormFacade.FormPutAsync(Data);
    }
}
