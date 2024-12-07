namespace FormsIW5.Web.BL;

public partial class QuestionApiClient
{
    public HttpClient HttpClient { set { _httpClient = value; } }
    partial void Initialize()
    {
        BaseUrl = _httpClient?.BaseAddress?.ToString();
    }
}
