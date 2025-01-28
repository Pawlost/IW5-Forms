namespace FormsIW5.Web.BL.Facades;

public class UtilsFacade : FacadeBase<IUtilsApiClient>
{
    public UtilsFacade(IHttpClientFactory clientFactory, IUtilsApiClient client) : base(clientFactory, client)
    {
    }

    public async Task<bool> IsAdmin(string clientName)
    {
        SwitchClient(clientName);
        var model = await client.IsAdminAsync();
        return model.IsAdmin is true;
    }
}
