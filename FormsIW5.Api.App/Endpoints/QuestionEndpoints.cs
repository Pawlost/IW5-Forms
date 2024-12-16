using FormsIW5.Api.App.Extensions;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.BL.Models.Common.Question;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class QuestionEndpoints
{
    public static IEndpointRouteBuilder AddQuestionEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("question").WithTags("question");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<QuestionEditModel> facade) => await facade.GetAllAsync());

        //Get all ids
        group.MapGet("questions/ids/{formId:guid}", async (Guid formId, [FromServices] IQuestionFacade facade) => await facade.GetQuestionsIdsAsync(formId));

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<QuestionEditModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<QuestionDetailModel> facade) => await facade.GetByIdAsync(id));

        // Search by text
        group.MapGet("searchByText/{formId:guid}", async (Guid formId, [FromQuery] string? text, [FromServices] IQuestionFacade facade) => 
        {
            return await facade.SearchByText(new QuestionQueryObject { TextMatch = text, FormId=formId });
        });

        // Search by description
        group.MapGet("searchByDescription/{formId:guid}", async (Guid formId, [FromQuery] string? description, [FromServices] IQuestionFacade facade) => 
        {
            return await facade.SearchByDescription(new QuestionQueryObject { TextMatch = description, FormId = formId });
        });

        //Create
        group.MapPost("", async (QuestionCreateModel newQuestion, [FromServices] ICreateFacade<QuestionCreateModel> facade, IHttpContextAccessor httpContextAccessor) => 
        {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            return await facade.CreateAsync(newQuestion, userId);
        });

        // Update
        group.MapPut("/question/update", async (QuestionEditModel question, [FromServices] IQuestionFacade facade) => await facade.UpdateListQuestion(question));

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IUpdateFacade<QuestionDetailModel> facade, IHttpContextAccessor httpContextAccessor) => {
            var userId = EndpointExtensions.GetUserId(httpContextAccessor);
            await facade.DeleteAsync(id, userId);
        });

        return endpointRoute;
    }
}
