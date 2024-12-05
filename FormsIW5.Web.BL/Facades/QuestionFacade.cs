using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Web.BL.Facades;

public class QuestionFacade : IWebFacade
{
    private readonly IQuestionApiClient apiClient;
    public QuestionFacade(IQuestionApiClient apiClient)
    {
        this.apiClient = apiClient;
    }
    public async Task<ICollection<QuestionListModel>> QuestionListGetAsync()
    {
        return await apiClient.QuestionGetAsync();
    }

    public async Task<Guid> QuestionPostAsync(QuestionCreateModel createModel)
    {
        return await apiClient.QuestionPostAsync(createModel);
    }

    public async Task<Guid?> QuestionPutAsync(QuestionDetailModel model)
    {
        return await apiClient.QuestionPutAsync(model);
    }
    public async Task<QuestionListModel> ListAsync(Guid id)
    {
        return await apiClient.ListAsync(id);
    }
    public async Task<QuestionDetailModel> QuestionGetAsync(Guid id)
    {
        return await apiClient.QuestionGetAsync(id);
    }
    public async Task QuestionDeleteAsync(Guid id)
    {
        await apiClient.QuestionDeleteAsync(id);
    }
}