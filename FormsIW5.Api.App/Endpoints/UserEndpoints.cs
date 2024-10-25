using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.User;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class UserEndpoints
{
    public static IEndpointRouteBuilder AddUserEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("user");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<UserListModel> facade) => await facade.GetAllAsync());

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<UserListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IDetailFacade<UserDetailModel> facade) => await facade.GetByIdAsync(id));

        // Search by user name
        group.MapGet("search", async ([FromQuery] string username, [FromServices] IUserFacade facade) => await facade.SearchByNameAsync(username));

        //Create
        group.MapPost("", async Task<Results<Ok<Guid>, Conflict<string>>> (UserDetailModel newUser,  [FromServices] IDetailFacade<UserDetailModel> facade) =>
        {
            if (Guid.Empty != newUser.Id && await facade.ExistsAsync(newUser.Id)) 
            {
                return TypedResults.Conflict("User already exists");
            }
            return TypedResults.Ok(await facade.CreateAsync(newUser));
        });

        // Update
        group.MapPut("", async (UserDetailModel user, [FromServices] IDetailFacade<UserDetailModel> facade) => await facade.UpdateAsync(user));

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IDetailFacade<UserDetailModel> facade) => await facade.DeleteAsync(id));

        return endpointRoute;
    }
}
