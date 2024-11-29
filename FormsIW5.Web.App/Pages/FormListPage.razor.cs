using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL.Facades;
using Microsoft.AspNetCore.Components;

namespace FormsIW5.Web.App.Pages;

public partial class FormListPage
{
    [Inject]
    private FormFacade facade { get; set; } = null!;

    ICollection<FormListModel> FormList { get; set; } = [];

    protected override async Task OnInitializedAsync() {
       
        FormList = await facade.FormGetAsync();
        await base.OnInitializedAsync();
    }
}
