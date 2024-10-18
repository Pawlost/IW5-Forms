using FormsIW5.Api.DAL.Installers;
using FormsIW5.Api.BL.Installers;
using FormsIW5.Api.DAL.Entities;
using FormsIW5.Api.BL.Facades;
using Microsoft.AspNetCore.Mvc;
using FormsIW5.Common.Installer;
using Microsoft.EntityFrameworkCore;
using FormsIW5.Common.BL.Models.User;

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

        builder.Services.Install<ApiDALInstaller>(builder.Configuration.GetConnectionString("DefaultConnectionString")!);
        builder.Services.Install<ApiBLInstaller>();
        var app = builder.Build();

        app.UseDeveloperExceptionPage();


        /* if (_dbOptions.RecreateDatabaseEachTime)
         {
             await dbContext.Database.EnsureDeletedAsync(cancellationToken);
         }*/


        //   await dbContext.Database.MigrateAsync(cancellationToken);

        app.UseCors();
        app.UseHttpsRedirection();

        app.UseRouting();

        app.MapGet("", ([FromServices] UserFacade userFacade) => userFacade.GetAll());
        app.MapPost("", ([FromBody] UserDetailModel newUser, [FromServices] UserFacade userFacade) => userFacade.Create(newUser));

        app.UseOpenApi();
        app.UseSwaggerUi();

        app.Run();
    }
}