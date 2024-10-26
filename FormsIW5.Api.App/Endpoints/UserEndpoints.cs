using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.Question;
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
        group.MapGet("{id:guid}", async Task<Results<Ok<UserDetailModel>, NotFound<string>, BadRequest<string>>> (Guid id, [FromServices] IDetailFacade<UserDetailModel> facade) =>
        {
            if (Guid.Empty == id)
            {
                return TypedResults.BadRequest("User id cannot be empty");
            }

            if (!await facade.ExistsAsync(id))
            {
                return TypedResults.NotFound("User not found");
            }

            return TypedResults.Ok(await facade.GetByIdAsync(id));
        });

        // Search by user name
        group.MapGet("search", async ([FromQuery] string username, [FromServices] IUserFacade facade) => await facade.SearchByNameAsync(username));

        //Create
        group.MapPost("", async Task<Results<Ok<Guid>, Conflict<string>>> (UserCreateModel newUser, [FromServices] IUserFacade facade) =>
        {
            if (await facade.UserNameExistsAsync(newUser.UserName))
            {
                return TypedResults.Conflict("User already exists");
            }
            return TypedResults.Ok(await facade.CreateAsync(newUser));
        });

        // Update
        group.MapPut("", async Task<Results<Ok<Guid?>, Conflict<string>, BadRequest<string>>> (UserDetailModel user, [FromServices] IUserFacade facade) =>
        {

            if (user.Id == Guid.Empty || !await facade.ExistsAsync(user.Id)) {
                return TypedResults.BadRequest("User id is not valid");
            }

            if (user.Id == Guid.Empty || !await facade.UserNameExistsAsync(user.UserName))
            {
                return TypedResults.Conflict("User name already exists, cannot update");
            }

            return TypedResults.Ok(await facade.UpdateAsync(user));

        });

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IDetailFacade<UserDetailModel> facade) => await facade.DeleteAsync(id));

        return endpointRoute;
    }
}
