using FormsIW5.Common.Installer;
using FormsIW5.Web.BL.Facades;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Web.BL.Installer;

public class WebBLInstaller : IClientInstaller
{
    public void Install(IServiceCollection serviceCollection, Uri? url)
    {
        var addBaseAddress = new Action<HttpClient>(client =>
        {
            client.BaseAddress = url;
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
