using FormsIW5.BL.Models.Common.Form;
using FormsIW5.Web.BL;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FormsIW5.Web.App.Pages;

public partial class FormListPage
{
    [Inject]
    private FormApiClient _httpClient { get; set; } = null!;

    ICollection<FormListModel> FormList { get; set; } = [];

    protected override async Task OnInitializedAsync() {
       
        FormList = await _httpClient.FormGetAsync();
        await base.OnInitializedAsync();
    }
}
