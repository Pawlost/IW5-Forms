using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Web.BL.Facades;

public class QuestionFacade : FacadeBase<IQuestionApiClient>
{
    public QuestionFacade(IQuestionApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<QuestionListModel>> QuestionListGetAsync()
    {
        return await client.QuestionGetAsync();
    }

    public async Task<Guid> QuestionPostAsync(QuestionCreateModel createModel)
    {
        return await client.QuestionPostAsync(createModel);
    }

    public async Task<Guid?> QuestionPutAsync(QuestionDetailModel model)
    {
        return await client.QuestionPutAsync(model);
    }
    public async Task<QuestionListModel> ListAsync(Guid id)
    {
        return await client.ListAsync(id);
    }
    public async Task<QuestionDetailModel> QuestionGetAsync(Guid id)
    {
        return await client.QuestionGetAsync(id);
    }
    public async Task QuestionDeleteAsync(Guid id)
    {
        await client.QuestionDeleteAsync(id);
    }
}
