using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Web.BL.Facades;

public class QuestionFacade : FacadeBase<IQuestionApiClient>
{
    public QuestionFacade(IQuestionApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<QuestionEditModel>> QuestionListGetAsync()
    {
        return await client.QuestionGetAsync();
    }

    public async Task<Guid> QuestionPostAsync(QuestionCreateModel createModel)
    {
        return await client.QuestionPostAsync(createModel);
    }

    public async Task QuestionPutAsync(QuestionEditModel model)
    {
        await client.UpdateQuestionAsync(model);
    }
    public async Task<QuestionEditModel> ListAsync(Guid id)
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

    public async Task<ICollection<QuestionListModel>> SearchByTextAsync(Guid id, string text)
    {
        return await client.SearchByTextAsync(id, text);
    }

    public async Task<ICollection<QuestionListModel>> SearchByDescriptionAsync(Guid id, string description)
    {
        return await client.SearchByDescriptionAsync(id, description);
    }
}
