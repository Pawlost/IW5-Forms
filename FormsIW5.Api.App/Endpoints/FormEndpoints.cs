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
        group.MapGet("", async ([FromServices] IListFacade<FormListModel> facade) => await facade.GetAllAsync());

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<FormListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IDetailFacade<FormDetailModel> facade) => await facade.GetByIdAsync(id));

        //Create
        group.MapPost("", async (FormCreateModel newForm, [FromServices] ICreateFacade<FormCreateModel> facade) => await facade.CreateAsync(newForm));

        // Update
        group.MapPut("", async (FormDetailModel form, [FromServices] IDetailFacade<FormDetailModel> facade) => await facade.UpdateAsync(form));

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IDetailFacade<FormDetailModel> facade) => await facade.DeleteAsync(id));

        return endpointRoute;
    }
}
