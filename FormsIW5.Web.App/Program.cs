using FormsIW5.Web.BL;
using FormsIW5.Web.BL.Installer;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FormsIW5.Common.Installer;

namespace FormsIW5.Web.App
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");
            var apiBaseUrl = builder.Configuration.GetValue<Uri>("ApiBaseUrl");

            builder.Services.Install<WebBLInstaller>(apiBaseUrl);

            await builder.Build().RunAsync();
        }
    }
}
