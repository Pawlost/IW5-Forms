using FormsIW5.Api.App.Extensions;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.BL.Models.Common.Answer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class AnswerEndpoints
{
    public static IEndpointRouteBuilder AddAnswerEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("answer").WithTags("answer");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<AnswerListModel> facade) => await facade.GetAllAsync());

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<AnswerListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<AnswerDetailModel> facade) => await facade.GetByIdAsync(id));

        group.MapGet("formAnswer/{id:guid}", async (Guid id, [FromServices] IAnswerFacade facade) => await facade.GetFormAnswersAsync(id));

        //Create
        group.MapPost("", async (AnswerCreateModel newAnswer, [FromServices] ICreateFacade<AnswerCreateModel> facade, IHttpContextAccessor httpContextAccessor) =>
            {
                var userId = EndpointExtensions.GetUserId(httpContextAccessor);
                return await facade.CreateAsync(newAnswer, userId);
            }
        );

        // Update
        group.MapPut("", async (AnswerDetailModel answer, [FromServices] IUpdateFacade<AnswerDetailModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            await facade.UpdateAsync(answer, userId);
        });

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<AnswerDetailModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            await facade.DeleteAsync(id, userId);
        });

        return endpointRoute;
    }
}
