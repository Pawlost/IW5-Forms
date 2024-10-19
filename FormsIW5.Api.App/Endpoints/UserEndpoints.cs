using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder AddUserEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("user");

        //Get all
        group.MapGet("", ([FromServices] IListFacade<UserListModel> userFacade) => userFacade.GetAll());


        //Get list model By Id
        group.MapGet("list/{id:guid}", (Guid id, [FromServices] IListFacade<UserListModel> userFacade) => userFacade.GetList(id));

        //Get detail By Id

        // Search by user name

        //Create
        group.MapPost("", (UserDetailModel newUser, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.Create(newUser));

        // Update

        // Delete
        group.MapDelete("{id:guid}", (Guid id, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.Delete(id));


        return endpointRoute;
    }
}
