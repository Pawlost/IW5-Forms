﻿using FormsIW5.BL.Models.Common.Form;

namespace FormsIW5.Web.BL.Facades;

public class FormFacade : FacadeBase<IFormApiClient>
{
    public FormFacade(IFormApiClient apiClient, IHttpClientFactory clientFactory) : base(clientFactory, apiClient)
    {
    }

    public async Task<ICollection<FormListModel>> FormGetAsync()
    {
        InitClient(ClientNames.AnonymousClientName);
        return await client.FormGetAsync();
    }

    public async Task<Guid> AnswerPostAsync(FormCreateModel createModel)
    {
        InitClient();
        return await client.FormPostAsync(createModel);
    }

    public async Task<Guid?> FormPutAsync(FormDetailModel model)
    {
        InitClient();
        return await client.FormPutAsync(model);
    }
    public async Task<FormListModel> ListAsync(Guid id)
    {
        InitClient();
        return await client.ListAsync(id);
    }
    public async Task<FormDetailModel> FormGetAsync(Guid id)
    {
        InitClient();
        return await client.FormGetAsync(id);
    }
    public async Task AnswerDeleteAsync(Guid id)
    {
        InitClient();
        await client.FormDeleteAsync(id);
    }
}
