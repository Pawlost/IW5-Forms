using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Api.App.Endpoints;
using FormsIW5.Api.DAL;
using FormsIW5.Api.DAL.Common.Entities;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using FormsIW5.Api.DAL.Installer;
using FormsIW5.Api.BL.Installer;
using FormsIW5.BL.Models.Common.Installers;

namespace FormsIW5.Api.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var enableIdentity = builder.Configuration?.GetValue<bool>("IdentityProvider:EnableIdentity") is true;

        if (enableIdentity) { 
            ConfigureAuthentication(builder.Services, builder.Configuration);
        }

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument();

        builder.Services.AddCors(options =>
        {
            options.AddDefaultPolicy(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddAutoMapper(typeof(EntityBase), typeof(ApiBLInstaller));


        if (builder.Environment.EnvironmentName != "QA")
        {
            builder.Services.Install<ApiDALInstaller>(builder.Configuration);
        }

        builder.Services.Install<ApiBLInstaller>(builder.Configuration);
        builder.Services.Install<ValidatorInstaller>(builder.Configuration);

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

        if (enableIdentity) {
            app.UseAuthentication();
            app.UseAuthorization();
        }

        AddEndpoints(app, enableIdentity);

        app.UseOpenApi();
        app.UseSwaggerUi();

        app.Run();
    }

    public static void MigrateDB(IServiceProvider services)
    {
        using var dbContext = services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
        dbContext.Database.Migrate();
    }

    public static void AddEndpoints(IEndpointRouteBuilder endpointRoute, bool enableIdentity)
    {
        var endpoints = endpointRoute.MapGroup("api").WithOpenApi();

        if (enableIdentity)
        {
            endpoints.RequireAuthorization();
        }

        endpoints.AddFormEndpoints()
            .AddQuestionEndpoints()
            .AddAnswerEndpoints()
            .AddQuestionOptionEndpoints()
            .AddUtilEndpoints();
    }

    public static void ConfigureAuthentication(IServiceCollection serviceCollection, IConfiguration? configuration)
    {
        var apiBaseUrl = configuration?.GetValue<string>("IdentityProvider:Authority");

        if (apiBaseUrl is null) 
        {
            throw new NullReferenceException("Identity provider must be set if enabled");
        }

        serviceCollection.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.Authority = apiBaseUrl;
                options.TokenValidationParameters.ValidateAudience = false;
                options.TokenValidationParameters.RoleClaimType = "role";
            });

        serviceCollection.AddAuthorizationBuilder()
            .AddPolicy("AdminPolicy", policy => policy.RequireRole("admin"));
        serviceCollection.AddHttpContextAccessor();
    }
}
