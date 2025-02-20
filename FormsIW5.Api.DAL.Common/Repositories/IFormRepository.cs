﻿using FormsIW5.Api.DAL.Common.Entities;

namespace FormsIW5.Api.DAL.Common.Repositories;

public interface IFormRepository : IApiRepository<FormEntity>
{
    Task<FormEntity?> GetFormDetailAsync(Guid id);
}
