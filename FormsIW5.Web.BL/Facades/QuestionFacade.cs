using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Web.BL.Facades;

public class QuestionFacade : FacadeBase<IQuestionApiClient>
{
    public QuestionFacade(IQuestionApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<QuestionEditModel>> QuestionListGetAsync()
    {
        SwitchClient();
        return await client.QuestionGetAsync();
    }

    public async Task<Guid> QuestionPostAsync(QuestionCreateModel createModel)
    {
        SwitchClient();
        return await client.QuestionPostAsync(createModel);
    }

    public async Task QuestionPutAsync(QuestionEditModel model)
    {
        SwitchClient();
        await client.UpdateAsync(model);
    }
    public async Task<QuestionEditModel> ListAsync(Guid id)
    {
        SwitchClient();
        return await client.ListAsync(id);
    }
    public async Task<QuestionDetailModel> GetQuestionDetailAsync(Guid id)
    {
        SwitchClient();
        return await client.QuestionGetAsync(id);
    }
    public async Task QuestionDeleteAsync(Guid id)
    {
        SwitchClient();
        await client.QuestionDeleteAsync(id);
    }

    public async Task<ICollection<QuestionListModel>> SearchByTextAsync(Guid id, string text)
    {
        SwitchClient();
        return await client.SearchByTextAsync(id, text);
    }

    public async Task<ICollection<QuestionListModel>> SearchByDescriptionAsync(Guid id, string description)
    {
        SwitchClient();
        return await client.SearchByDescriptionAsync(id, description);
    }

    public async Task<ICollection<Guid>> GetQuestionsIdsAsync(Guid formId)
    {
        SwitchClient();
        return await client.IdsAsync(formId);
    }
}
