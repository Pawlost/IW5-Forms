using FormsIW5.Api.App;
using FormsIW5.DAL;
using FormsIW5.DAL.Installers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

        // builder.Services.InstallDAL("");

        var app = builder.Build();

        app.UseCors();
        app.UseHttpsRedirection();

        app.UseRouting();

        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        app.MapGet("/", (HttpContext httpContext) =>
        {
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = summaries[Random.Shared.Next(summaries.Length)]
                })
                .ToArray();
            return forecast;
        }).WithOpenApi();

        app.UseOpenApi();
        app.UseSwaggerUi();

        app.Run();
    }
}