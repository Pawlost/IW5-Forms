using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Web.BL.Facades;

public class AnswerFacade : FacadeBase<IAnswerApiClient>
{
    public AnswerFacade(IAnswerApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<AnswerListModel>> GetAnswerAsync()
    {
        return await client.AnswerGetAsync();
    }

    public async Task<AnswerDetailModel> GetUserAnswerAsync(Guid questionId)
    {
        return await client.GetUserAnswerAsync(questionId);
    }
    public async Task<bool> GetHasUserAnsweredAsync(Guid questionId)
    {
        return await client.IsUserAnswerAsync(questionId);
    }

    public async Task<Guid> PostAnswerAsync(AnswerCreateModel createModel)
    {
        return await client.AnswerPostAsync(createModel);
    }

    public async Task PutAnswerAsync(AnswerDetailModel model)
    {
        await client.AnswerPutAsync(model);
    }

    public async Task<AnswerListModel> ListAnswerAsync(Guid id)
    {
        return await client.ListAsync(id);
    }
    public async Task<AnswerDetailModel> GetAnswerAsync(Guid id)
    {
        return await client.AnswerGetAsync(id);
    }

    public async Task DeleteAnswerAsync(Guid id)
    {
        await client.AnswerDeleteAsync(id);
    }
}
