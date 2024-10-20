using FormsIW5.Api.BL.Facades;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.Form;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class QuestionEndpoints
{
    public static IEndpointRouteBuilder AddQuestionEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("question");

        //Get all
        group.MapGet("", ([FromServices] IListFacade<QuestionListModel> facade) => facade.GetAll());

        //Get list model By Id
        group.MapGet("list/{id:guid}", (Guid id, [FromServices] IListFacade<QuestionListModel> facade) => facade.GetSingleListModelById(id));

        //Get detail By Id
        group.MapGet("{id:guid}", (Guid id, [FromServices] IDetailFacade<QuestionDetailModel> facade) => facade.GetById(id));

        // Search by text
        group.MapGet("search", ([FromQuery] string? textAnswer, [FromQuery] string? description, [FromServices] IQuestionFacade facade) => facade.SearchByTextOrByDescription(textAnswer, description));

        //Create
        group.MapPost("", (QuestionDetailModel newForm, [FromServices] IDetailFacade<QuestionDetailModel> facade) => facade.Create(newForm));

        // Update
        group.MapPut("", (QuestionDetailModel form, [FromServices] IDetailFacade<QuestionDetailModel> facade) => facade.Update(form));

        // Delete
        group.MapDelete("{id:guid}", (Guid id, [FromServices] IDetailFacade<QuestionDetailModel> facade) => facade.Delete(id));

        return endpointRoute;
    }
}