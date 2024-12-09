using System.Security.Claims;

namespace FormsIW5.Api.App.Extensions;

public class EndpointExtensions
{
    public static string? GetUserId(IHttpContextAccessor httpContextAccessor)
    {
        var idClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier);
        return idClaim?.Value;
    }
}
