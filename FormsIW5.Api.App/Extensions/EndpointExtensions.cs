using System.Security.Claims;
using FormsIW5.Api.DAL.Common.Queries;

namespace FormsIW5.Api.App.Extensions;

public static class EndpointExtensions
{
    public static string? GetUserId(this IHttpContextAccessor httpContextAccessor)
    {
        var idClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return idClaim?.Value;
    }

    public static bool? IsAdmin(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor?.HttpContext?.User.HasClaim(x => x.Type == ClaimTypes.Role);
    }

    public static OwnerQueryObject ToUserQuery(this IHttpContextAccessor httpContextAccessor)
    {
        return new()
        {
            OwnerId = httpContextAccessor.GetUserId(),
            IsAdmin = httpContextAccessor.IsAdmin()
         }; 
    }
}
