using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Web.BL.Facades;

public class AnswerFacade : FacadeBase<IAnswerApiClient>
{
    public AnswerFacade(IAnswerApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<AnswerListModel>> AnswerGetAsync()
    {
        return await client.AnswerGetAsync();
    }

    public async Task<Guid> AnswerPostAsync(AnswerCreateModel createModel)
    {
        return await client.AnswerPostAsync(createModel);
    }

    public async Task<Guid?> AnswerPutAsync(AnswerDetailModel model)
    {
        return await client.AnswerPutAsync(model);
    }

    public async Task<AnswerListModel> ListAsync(Guid id)
    {
        return await client.ListAsync(id);
    }
    public async Task<AnswerDetailModel> AnswerGetAsync(Guid id)
    {
        return await client.AnswerGetAsync(id);
    }

    public async Task<ICollection<AnswerDetailModel>> GetFormAnswersAsync(Guid id)
    {
        return await client.FormAnswerAsync(id);
    }

    public async Task AnswerDeleteAsync(Guid id)
    {
        await client.AnswerDeleteAsync(id);
    }
}
