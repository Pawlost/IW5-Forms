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
        group.MapGet("list/{id:guid}", (Guid id, [FromServices] IListFacade<UserListModel> userFacade) => userFacade.GetSingleListModelById(id));

        //Get detail By Id
        group.MapGet("{id:guid}", (Guid id, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.GetById(id));

        // Search by user name
        group.MapGet("search", ([FromQuery] string username, [FromServices] IUserFacade userFacade) => userFacade.SearchByName(username));

        //Create
        group.MapPost("", (UserDetailModel newUser, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.Create(newUser));

        // Update
        group.MapPut("", (UserDetailModel user, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.Update(user));

        // Delete
        group.MapDelete("{id:guid}", (Guid id, [FromServices] IDetailFacade<UserDetailModel> userFacade) => userFacade.Delete(id));

        return endpointRoute;
    }
}
