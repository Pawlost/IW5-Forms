namespace FormsIW5.Web.BL;

public partial class AnswerApiClient
{
    partial void Initialize() {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
