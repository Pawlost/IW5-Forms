using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Web.BL.Facades;

public class QuestionFacade : FacadeBase<IQuestionApiClient>
{
    public QuestionFacade(IQuestionApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<QuestionEditModel>> QuestionListGetAsync()
    {
        InitClient();
        return await client.QuestionGetAsync();
    }

    public async Task<Guid> QuestionPostAsync(QuestionCreateModel createModel)
    {
        InitClient();
        return await client.QuestionPostAsync(createModel);
    }

    public async Task QuestionPutAsync(QuestionEditModel model)
    {
        InitClient();
        await client.UpdateQuestionAsync(model);
    }
    public async Task<QuestionEditModel> ListAsync(Guid id)
    {
        InitClient();
        return await client.ListAsync(id);
    }
    public async Task<QuestionDetailModel> QuestionGetAsync(Guid id)
    {
        InitClient();
        return await client.QuestionGetAsync(id);
    }
    public async Task QuestionDeleteAsync(Guid id)
    {
        InitClient();
        await client.QuestionDeleteAsync(id);
    }

    public async Task<ICollection<QuestionListModel>> SearchByTextAsync(Guid id, string text)
    {
        InitClient();
        return await client.SearchByTextAsync(id, text);
    }

    public async Task<ICollection<QuestionListModel>> SearchByDescriptionAsync(Guid id, string description)
    {
        InitClient();
        return await client.SearchByDescriptionAsync(id, description);
    }

    public async Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId)
    {
        InitClient();
        return await client.GetQuestionsIdsAsync(formId);
    }
}
