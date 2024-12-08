using FormsIW5.Web.BL.Clients.Interfaces;
using FormsIW5.Web.BL.Facades.Interfaces;

namespace FormsIW5.Web.BL.Facades
{
    public abstract class FacadeBase<TClient> : IWebFacade
        where TClient : IModifiableClient
    {
        private readonly IHttpClientFactory clientFactory;
        protected readonly TClient client;
        private readonly HttpClient originalClient;

        public FacadeBase(IHttpClientFactory clientFactory, TClient client)
        {
            this.client = client;
            originalClient = client.HttpClient;
            this.clientFactory = clientFactory;
        }

        protected void InitClient(string? clientName = null) {
            if (clientName is null)
            {
                client.HttpClient = originalClient;
            } 
            else 
            {
                client.HttpClient = clientFactory.CreateClient(clientName);
            }
        }
    }
}
