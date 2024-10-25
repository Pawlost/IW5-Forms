﻿using AutoMapper;
using FormsIW5.Api.BL.Facades.Interfaces;
using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Repositories;
using FormsIW5.Common.BL.Models.Answer;

namespace FormsIW5.Api.BL.Facades;

public class AnswerFacade : FacadeBase<AnswerEntity, AnswerListModel, AnswerDetailModel, IAnswerRepository>, IAnswerFacade
{
    public AnswerFacade(IAnswerRepository repository, IMapper mapper) : base(repository, mapper)
    {
    }
}
