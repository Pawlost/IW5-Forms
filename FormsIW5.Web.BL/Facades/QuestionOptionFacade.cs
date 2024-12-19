namespace FormsIW5.Web.BL.Facades;

public class QuestionOptionFacade : FacadeBase<IQuestionOptionsApiClient>
{
    public QuestionOptionFacade(IQuestionOptionsApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }
    public async Task QuestionOptionDeleteAsync(Guid id)
    {
        SwitchClient();
        await client.OptionsAsync(id);
    }
}
