﻿using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Common.BL.Models.Answer;
using FormsIW5.Common.BL.Models.Form;
using Microsoft.AspNetCore.Mvc;

namespace FormsIW5.Api.App.Endpoints;

public static class AnswerEndpoints
{
    public static IEndpointRouteBuilder AddAnswerEndpoints(this IEndpointRouteBuilder endpointRoute)
    {
        var group = endpointRoute.MapGroup("answer");

        //Get all
        group.MapGet("", async ([FromServices] IListFacade<AnswerListModel> facade) => await facade.GetAllAsync());

        //Get list model By Id
        group.MapGet("list/{id:guid}", async (Guid id, [FromServices] IListFacade<AnswerListModel> facade) => await facade.GetSingleListModelByIdAsync(id));

        //Get detail By Id
        group.MapGet("{id:guid}", async (Guid id, [FromServices] IDetailFacade<AnswerDetailModel> facade) => await facade.GetByIdAsync(id));

        //Create
        group.MapPost("", async (AnswerDetailModel newAnswer, [FromServices] IDetailFacade<AnswerDetailModel> facade) => await facade.CreateAsync(newAnswer));

        // Update
        group.MapPut("", async (AnswerDetailModel answer, [FromServices] IDetailFacade<AnswerDetailModel> facade) => await facade.UpdateAsync(answer));

        // Delete
        group.MapDelete("{id:guid}", async (Guid id, [FromServices] IDetailFacade<AnswerDetailModel> facade) => await facade.DeleteAsync(id));

        return endpointRoute;
    }
}
