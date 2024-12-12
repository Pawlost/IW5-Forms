﻿using FormsIW5.Api.App.Extensions;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.BL.Models.Common.Form;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class FormEndpoints
{
    public static IEndpointRouteBuilder AddFormEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("form").WithTags("form");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<FormListModel> facade) => await facade.GetAllAsync()).AllowAnonymous();

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<FormListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get edit By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<FormEditModel> facade) => await facade.GetByIdAsync(id)).AllowAnonymous();

        //Create
        group.MapPost("", async (FormCreateModel newForm, [FromServices] ICreateFacade<FormCreateModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            return await facade.CreateAsync(newForm, userId);
        });

        // Update
        group.MapPut("", async (FormEditModel form, [FromServices] IUpdateFacade<FormEditModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            return await facade.UpdateAsync(form, userId);
        });

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IAppFacadeBase facade, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            await facade.DeleteAsync(id, userId);
        });

        return endpointRoute;
    }
}
