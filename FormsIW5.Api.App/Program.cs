using FormsIW5.Api.DAL.Installers;
using FormsIW5.Api.BL.Installers;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Api.App.Endpoints;
using FormsIW5.Api.DAL;

namespace FormsIW5.Api.App;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddOpenApiDocument();

        builder.Services.AddCors(options => {
            options.AddDefaultPolicy(o => o.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        });

        builder.Services.AddAutoMapper(typeof(EntityBase), typeof(ApiBLInstaller));

        builder.Services.Install<ApiDALInstaller>(builder.Configuration.GetConnectionString("DefaultConnection")!);
        builder.Services.Install<ApiBLInstaller>();

        var app = builder.Build();

    /*    var dbContext = app.Services.CreateScope().ServiceProvider.GetRequiredService<FormsIW5DbContext>();
        dbContext.Database.Migrate();*/

        var environment = app.Services.GetRequiredService<IWebHostEnvironment>();

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

    public static void AddEndpoints(IEndpointRouteBuilder endpointRoute)
    {
        endpointRoute.MapGroup("api").WithOpenApi()
            .AddUserEndpoints()
            .AddFormEndpoints()
            .AddQuestionEndpoints()
            .AddAnswerEndpoints();
    }
}