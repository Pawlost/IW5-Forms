using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Web.BL.Facades;

public class FormFacade : FacadeBase<IFormApiClient>
{
    public FormFacade(IFormApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<FormListModel>> GetAllAsync()
    {
        SwitchClient(ClientNames.AnonymousClientName);
        return await client.FormGetAsync();
    }

    public async Task<Guid> FormPostAsync(FormCreateModel createModel)
    {
        SwitchClient();
        return await client.FormPostAsync(createModel);
    }

    public async Task<Guid?> FormEditAsync(FormEditModel model)
    {
        SwitchClient();
        return await client.FormPutAsync(model);
    }
    public async Task<FormListModel> ListAsync(Guid id)
    {
        SwitchClient();
        return await client.ListAsync(id);
    }
    public async Task<FormDetailModel> GetDetailAsync(Guid id, string clientName = ClientNames.AnonymousClientName)
    {
        SwitchClient(clientName);
        return await client.DetailAsync(id);
    }
    public async Task<FormEditModel> GetEditAsync(Guid id)
    {
        SwitchClient();
        return await client.EditAsync(id);
    }
    public async Task FormDeleteAsync(Guid id)
    {
        SwitchClient();
        await client.FormDeleteAsync(id);
    }
}
