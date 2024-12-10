﻿using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IAnswerRepository : IApiRepository<AnswerEntity>
{
    public Task<ICollection<AnswerEntity>> GetFormAnswersAsync(Guid formId);
}
