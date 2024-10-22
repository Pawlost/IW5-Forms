using System.Reflection;
using FormsIW5.Api.DAL;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;

namespace FormsIW5.Api.App.EndToEndTests;

public class FormsIW5ApiApplicationFactory : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(collection =>
        {
            var controllerAssemblyName = typeof(Program).Assembly.FullName;
            collection.AddMvc().AddApplicationPart(Assembly.Load(controllerAssemblyName));

          /*  collection.AddDbContext<FormsIW5DbContext>(options =>
            options.UseSqlServer(connectionString));*/
        });

        return base.CreateHost(builder);
    }
}
