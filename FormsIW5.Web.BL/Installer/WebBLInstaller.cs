using FormsIW5.Common.Installer;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Web.BL.Installer;

public class WebBLInstaller : IClientInstaller
{
    public void Install(IServiceCollection serviceCollection, string url)
    {
      /*  serviceCollection.AddTransient<IRecipeApiClient, RecipeApiClient>(provider =>
        {
            var client = CreateApiHttpClient(provider, apiBaseUrl);
            return new RecipeApiClient(client, apiBaseUrl);
        });

        serviceCollection.AddTransient<IIngredientApiClient, IngredientApiClient>(provider =>
        {
            var client = CreateApiHttpClient(provider, apiBaseUrl);
            return new IngredientApiClient(client, apiBaseUrl);
        });

        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<WebBLInstaller>()
                .AddClasses(classes => classes.AssignableTo<IAppFacade>())
                .AsSelfWithInterfaces()
                .WithTransientLifetime());*/
    }
}
