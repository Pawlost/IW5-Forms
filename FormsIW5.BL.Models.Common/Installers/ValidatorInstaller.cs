using FluentValidation;
using FormsIW5.Common.Installer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FormsIW5.BL.Models.Common.Installers
{
    public class ValidatorInstaller : IInstaller
    {
        public void Install(IServiceCollection serviceCollection, IConfiguration? configuration)
        {
            serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ValidatorInstaller>()
            .AddClasses(classes => classes.AssignableTo<IValidator>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
        }
    }
}
