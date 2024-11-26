﻿using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Common.BL.Models.Question;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class QuestionEndpoints
{
    public static IEndpointRouteBuilder AddQuestionEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("question").WithTags("question");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<QuestionListModel> facade) => await facade.GetAllAsync());

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<QuestionListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IDetailFacade<QuestionDetailModel> facade) => await facade.GetByIdAsync(id));

        // Search by text
        group.MapGet("search", async ([FromQuery] string? text, [FromQuery] string? description, [FromServices] IQuestionFacade facade) => await facade.Search(new QuestionQueryObject { Text = text, Description = description }));

        //Create
        group.MapPost("", async (QuestionCreateModel newQuestion, [FromServices] ICreateFacade<QuestionCreateModel> facade) => await facade.CreateAsync(newQuestion));

        // Update
        group.MapPut("", async (QuestionDetailModel question, [FromServices] IDetailFacade<QuestionDetailModel> facade) => await facade.UpdateAsync(question));

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IDetailFacade<QuestionDetailModel> facade) => await facade.DeleteAsync(id));

        return endpointRoute;
    }
}