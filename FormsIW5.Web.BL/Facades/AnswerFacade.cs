using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Web.BL.Facades;

public class AnswerFacade : FacadeBase
{
    private readonly IAnswerApiClient apiClient;
    public AnswerFacade(IAnswerApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory)
    {
        this.apiClient = apiClient;
    }
    public async Task<ICollection<AnswerListModel>> AnswerGetAsync()
    {
        return await apiClient.AnswerGetAsync();
    }

    public async Task<Guid> AnswerPostAsync(AnswerCreateModel createModel)
    {
        return await apiClient.AnswerPostAsync(createModel);
    }

    public async Task<Guid?> AnswerPutAsync(AnswerDetailModel model)
    {
        return await apiClient.AnswerPutAsync(model);
    }
    public async Task<AnswerListModel> ListAsync(Guid id)
    {
        return await apiClient.ListAsync(id);
    }
    public async Task<AnswerDetailModel> AnswerGetAsync(Guid id)
    {
        return await apiClient.AnswerGetAsync(id);
    }
    public async Task AnswerDeleteAsync(Guid id)
    {
        await apiClient.AnswerDeleteAsync(id);
    }
}
