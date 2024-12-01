using FormsIW5.Common.Installer;
using FormsIW5.Web.BL.Facades;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Web.BL.Installer;

public class WebBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration configuration)
    {
        var apiBaseUrl = configuration.GetValue<Uri>("ApiBaseUrl");

        var addBaseAddress = new Action<HttpClient>(client =>
        {
            client.BaseAddress = apiBaseUrl;
        });

        serviceCollection.AddHttpClient<IUserApiClient, UserApiClient>(addBaseAddress);
        serviceCollection.AddHttpClient<IFormApiClient, FormApiClient>(addBaseAddress);
        serviceCollection.AddHttpClient<IQuestionApiClient, QuestionApiClient>(addBaseAddress);
        serviceCollection.AddHttpClient<IAnswerApiClient, AnswerApiClient>(addBaseAddress);

        serviceCollection.Scan(selector =>
             selector.FromAssemblyOf<WebBLInstaller>()
                 .AddClasses(classes => classes.AssignableTo<IWebFacade>())
                 .AsSelfWithInterfaces()
                 .WithTransientLifetime());
    }
}
