using FormsIW5.Web.BL;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace FormsIW5.Web.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Configuration.AddJsonFile("appsettings.json");

            builder.Services.AddHttpClient<FormApiClient>(client =>
            {
                var apiBaseUrl = builder.Configuration.GetValue<Uri>("ApiBaseUrl");
                client.BaseAddress = apiBaseUrl;
            });

            await builder.Build().RunAsync();
        }
    }
}
