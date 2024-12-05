namespace FormsIW5.Web.BL;

public partial class QuestionApiClient
{
    partial void Initialize() {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
