namespace FormsIW5.Web.BL;

public partial class UserApiClient
{
    partial void Initialize() {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
