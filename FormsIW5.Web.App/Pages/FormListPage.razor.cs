using FormsIW5.Common.BL.Models.Form;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;

namespace FormsIW5.Web.App.Pages;

public partial class FormListPage
{
    [Inject]
    private HttpClient _httpClient { get; set; } = null!;

    IList<FormListModel> FormList { get; set; } = [];

    protected override async Task OnInitializedAsync() {
        FormList = await _httpClient.GetFromJsonAsync<List<FormListModel>>("");
        await base.OnInitializedAsync();
    }
}
