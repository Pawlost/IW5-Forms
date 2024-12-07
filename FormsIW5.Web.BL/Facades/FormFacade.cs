using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Web.BL.Facades;

public class FormFacade : FacadeBase
{
    private readonly IFormApiClient apiClient;

    public FormFacade(IFormApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory)
    {
        this.apiClient = apiClient;
    }

    public async Task<ICollection<FormListModel>> FormGetAsync()
    {
        apiClient.HttpClient = clientFactory.CreateClient(AnonymousClientName);
        return await apiClient.FormGetAsync();
    }

    public async Task<Guid> AnswerPostAsync(FormCreateModel createModel)
    {
        return await apiClient.FormPostAsync(createModel);
    }

    public async Task<Guid?> FormPutAsync(FormDetailModel model)
    {
        return await apiClient.FormPutAsync(model);
    }
    public async Task<FormListModel> ListAsync(Guid id)
    {
        return await apiClient.ListAsync(id);
    }
    public async Task<FormDetailModel> FormGetAsync(Guid id)
    {
        return await apiClient.FormGetAsync(id);
    }
    public async Task AnswerDeleteAsync(Guid id)
    {
        await apiClient.FormDeleteAsync(id);
    }
}
