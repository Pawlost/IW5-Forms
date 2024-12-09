using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Components;

public partial class FormEditFormComponent
{
    [Inject]
    private FormFacade FormFacade { get; set; } = null!;

    [Parameter]
    public required Guid FormId { get; set; }

    private FormDetailModel Data { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Data = await FormFacade.FormGetAsync(FormId);
        await base.OnInitializedAsync();
    }

    public async Task AddQuestionAsync()
    {
        await Task.CompletedTask;
    }

    public async Task SaveAsync() {
        await FormFacade.FormPutAsync(Data);
    }
}
