using FormsIW5.Api.App.Extensions;
using FormsIW5.Api.BL.Facades.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class QuestionOptionEndpoints
{
    public static IEndpointRouteBuilder AddQuestionOptionEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("options").WithTags("QuestionOptions");

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IQuestionOptionFacade facade, IHttpContextAccessor httpContextAccessor) => {
            await facade.DeleteAsync(id, httpContextAccessor.ToUserQuery());
        });

        return endpointRoute;
    }
}
