using FormsIW5.Web.BL.Facades.Interfaces;

namespace FormsIW5.Web.BL.Facades
{
    public abstract class FacadeBase : IWebFacade
    {
        public const string AnonymousClientName = "anonymous";
        public const string LogInClientName = "api";

        protected readonly IHttpClientFactory clientFactory;

        public FacadeBase(IHttpClientFactory clientFactory)
        {
            this.clientFactory = clientFactory;
        }
    }
}
