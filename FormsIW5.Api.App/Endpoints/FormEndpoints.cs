using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class FormEndpoints
{
    public static IEndpointRouteBuilder AddFormEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("form");

        //Get all
        group.MapGet("", ([FromServices] IListFacade<FormListModel> facade) => facade.GetAll());

        //Get list model By Id
        group.MapGet("list/{id:guid}", (Guid id, [FromServices] IListFacade<FormListModel> facade) => facade.GetSingleListModelById(id));

        //Get detail By Id
        group.MapGet("{id:guid}", (Guid id, [FromServices] IDetailFacade<FormDetailModel> facade) => facade.GetById(id));

        //Create
        group.MapPost("", (FormDetailModel newForm, [FromServices] IDetailFacade<FormDetailModel> facade) => facade.Create(newForm));

        // Update
        group.MapPut("", (FormDetailModel form, [FromServices] IDetailFacade<FormDetailModel> facade) => facade.Update(form));

        // Delete
        group.MapDelete("{id:guid}", (Guid id, [FromServices] IDetailFacade<FormDetailModel> facade) => facade.Delete(id));

        return endpointRoute;
    }
}
