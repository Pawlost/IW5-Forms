using FormsIW5.Api.BL.Facades;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.Installer;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FormsIW5.Api.BL.Installers;

public class ApiBLInstaller : IInstaller
{
    public void Install(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<QuestionFacade>();
        serviceCollection.Scan(selector =>
            selector.FromAssemblyOf<ApiBLInstaller>()
            .AddClasses(classes => classes.AssignableTo<IAppFacadeBase>())
            .AsSelfWithInterfaces()
            .WithScopedLifetime());
    }
}
