using FormsIW5.Web.BL.Clients.Interfaces;
using FormsIW5.Web.BL.Facades.Interfaces;

namespace FormsIW5.Web.BL.Facades
{
    public abstract class FacadeBase : IWebFacade
    {
        public const string AnonymousClientName = "anonymous";
        public const string LogInClientName = "api";

        private readonly IHttpClientFactory clientFactory;
        private readonly IModifiableClient client;
        private readonly HttpClient originalClient;


        public FacadeBase(IHttpClientFactory clientFactory, IModifiableClient client)
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
