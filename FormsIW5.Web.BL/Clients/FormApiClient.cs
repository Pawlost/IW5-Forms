namespace FormsIW5.Web.BL;

public partial class FormApiClient
{
    partial void Initialize() {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
