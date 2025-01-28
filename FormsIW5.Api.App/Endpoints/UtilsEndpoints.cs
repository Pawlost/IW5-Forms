using FormsIW5.Api.App.Extensions;
using FormsIW5.BL.Models.Common.Util;
namespace FormsIW5.Api.App.Endpoints;

public static class UtilsEndpoints
{
    public static IEndpointRouteBuilder AddUtilEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("utils").WithTags("utils");

        //Get all
        group.MapGet("isAdmin", (IHttpContextAccessor httpContextAccessor) => new UserRoleModel() { IsAdmin = httpContextAccessor.IsAdmin() }).AllowAnonymous();

        return endpointRoute;
    }
}
