namespace FormsIW5.Api.App.Endpoints;

public static class FormEndpoints
{
    public static IEndpointRouteBuilder AddFormEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("form");

        //Get all

        //Get detail By Id

        //Get list By Id

        // Search by text

        // Search by description

        //Create

        // Update

        // Delete
        return endpointRoute;
    }
}
