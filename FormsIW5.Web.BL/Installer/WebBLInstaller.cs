using FormsIW5.Common.Installer;
using FormsIW5.Web.BL.Facades.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.Web.BL.Installer;

public class WebBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        serviceCollection.AddScoped<IFormApiClient, FormApiClient>();
        serviceCollection.AddScoped<IQuestionOptionsApiClient, QuestionOptionsApiClient>();
        serviceCollection.AddScoped<IQuestionApiClient, QuestionApiClient>();
        serviceCollection.AddScoped<IAnswerApiClient, AnswerApiClient>();
        serviceCollection.AddScoped<IUserApiClient, UserApiClient>();

        serviceCollection.Scan(selector =>
           selector.FromAssemblyOf<WebBLInstaller>()
         .AddClasses(classes => classes.AssignableTo<IWebFacade>())
         .AsSelfWithInterfaces()
         .WithTransientLifetime());
    }
}
