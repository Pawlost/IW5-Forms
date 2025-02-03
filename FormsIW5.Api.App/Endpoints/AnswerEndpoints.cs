using FormsIW5.Api.App.Extensions;
using FormsIW5.Api.App.Filters;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.BL.Models.Common.Answer;
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

        //Get list model By Id
        group.MapGet("getUserAnswer/{questionId:guid}", async (Guid questionId, [FromServices] IAnswerFacade facade, IHttpContextAccessor httpContextAccessor) =>
        {
            return await facade.GetUserAnswer(questionId, httpContextAccessor.ToOwnerQuery());
        });

        //Get list model By Id
        group.MapGet("isUserAnswer/{questionId:guid}", async (Guid questionId, [FromServices] IAnswerFacade facade, IHttpContextAccessor httpContextAccessor) =>
        {
            return await facade.HasQuestionUserAnswer(questionId, httpContextAccessor.ToOwnerQuery());
        });

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<AnswerDetailModel> facade) => await facade.GetByIdAsync(id));

        //Create
        group.MapPost("", async (AnswerCreateModel newAnswer, [FromServices] ICreateFacade<AnswerCreateModel> facade, IHttpContextAccessor httpContextAccessor) =>
            {
                return await facade.CreateAsync(newAnswer, httpContextAccessor.ToOwnerQuery());
            }).AddEndpointFilter<ValidationFilter<AnswerCreateModel>>();

        // Update
        group.MapPut("", async (AnswerDetailModel answer, [FromServices] IUpdateFacade<AnswerDetailModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            await facade.UpdateAsync(answer, httpContextAccessor.ToOwnerQuery());
        }).AddEndpointFilter<ValidationFilter<AnswerDetailModel>>();

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<AnswerDetailModel> facade, IHttpContextAccessor httpContextAccessor) =>
        {
            await facade.DeleteAsync(id, httpContextAccessor.ToOwnerQuery());
        });

        return endpointRoute;
    }
}
