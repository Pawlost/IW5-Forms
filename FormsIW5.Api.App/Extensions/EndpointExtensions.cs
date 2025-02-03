using System.Security.Claims;
using FormsIW5.Api.BL.Queries;

namespace FormsIW5.Api.App.Extensions;

public static class EndpointExtensions
{
    public static string? GetOwnerId(this IHttpContextAccessor httpContextAccessor)
    {
        var idClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return idClaim?.Value;
    }

    public static bool IsAdmin(this IHttpContextAccessor httpContextAccessor)
    {
        return httpContextAccessor?.HttpContext?.User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "admin") is true;
    }

    public static OwnerQueryParameters ToOwnerQuery(this IHttpContextAccessor httpContextAccessor)
    {
        return new()
        {
            OwnerId = httpContextAccessor.GetOwnerId(),
            IsAdmin = httpContextAccessor.IsAdmin()
         }; 
    }
}
