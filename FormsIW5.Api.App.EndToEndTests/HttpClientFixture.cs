
namespace FormsIW5.Api.App.EndToEndTests
{
    public class HttpClientFixture : IAsyncLifetime
    {
        public HttpClient Client;
        public FormsIW5ApiApplicationFactory Application { get; set; }
        public HttpClientFixture()
        {
            Application = new FormsIW5ApiApplicationFactory();
            Client = Application.CreateClient();
        }

        public async Task InitializeAsync()
        {
            await Application.MigrateAsync();
        }

        public async Task DisposeAsync()
        {
            await Application.DisposeAsync();
        }
    }
}
