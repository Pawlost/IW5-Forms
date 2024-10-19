using FormsIW5.Api.BL.Facades;
using FormsIW5.Common.BL.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class QuestionEndpoints
{
    public static IEndpointRouteBuilder AddQuestionEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("question");

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
