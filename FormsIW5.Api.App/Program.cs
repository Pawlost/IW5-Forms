using FormsIW5.Api.DAL.Installers;
using FormsIW5.Api.BL.Installers;
using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Api.App.Endpoints;
using FormsIW5.Api.DAL;
using FormsIW5.Api.App.Configurations;
using Microsoft.Extensions.Options;
using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddAutoMapper(typeof(EntityBase), typeof(ApiBLInstaller));


        if (builder.Environment.EnvironmentName != "QA")
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string not found.");
            }

            builder.Services.Install<ApiDALInstaller>(connectionString!);
        }

        builder.Services.Install<ApiBLInstaller>();

        builder.Services.AddOptions<MigrationConfiguration>()
            .BindConfiguration("MigrationOptions")
            .ValidateDataAnnotations()
            .ValidateOnStart();

        var app = builder.Build();


        var environment = app.Services.GetRequiredService<IWebHostEnvironment>();

        if (environment.EnvironmentName != "QA")
        {
            MigrateDB(app.Services);
        }

        if (environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseCors();
        app.UseHttpsRedirection();

        app.UseRouting();

        AddEndpoints(app);

        app.UseOpenApi();
        app.UseSwaggerUi();

        app.Run();
    }

    public static void MigrateDB(IServiceProvider services) {

        var configuration = services.GetRequiredService<IOptions<MigrationConfiguration>>();

        if (configuration.Value.ApplyMigration)
        {
            using var dbContext = services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();

            dbContext.Database.Migrate();
        }
    }

    public static void AddEndpoints(IEndpointRouteBuilder endpointRoute)
    {
        endpointRoute.MapGroup("api").WithOpenApi()
            .AddUserEndpoints()
            .AddFormEndpoints()
            .AddQuestionEndpoints()
            .AddAnswerEndpoints();
    }
}