using FormsIW5.Web.BL.Clients.Interfaces;
using FormsIW5.Web.BL.Facades.Interfaces;

namespace FormsIW5.Web.BL.Facades
{
    public abstract class FacadeBase<TClient> : IWebFacade
        where TClient : IModifiableClient
    {
        private readonly IHttpClientFactory clientFactory;
        protected readonly TClient client;

        public FacadeBase(IHttpClientFactory clientFactory, TClient client)
        {
            this.client = client;
            this.clientFactory = clientFactory;
        }

        protected void SwitchClient(string? clientName = null) {
            if (clientName is null)
            {
                client.HttpClient = clientFactory.CreateClient(ClientNames.LogInApiClientName);
            } 
            else 
            {
                client.HttpClient = clientFactory.CreateClient(clientName);
            }
        }
    }
}
