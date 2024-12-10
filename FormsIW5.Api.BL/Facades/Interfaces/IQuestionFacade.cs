﻿using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.BL.Models.Common.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IQuestionFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionEditModel>, ICreateFacade<QuestionCreateModel>
{
    Task<ICollection<QuestionListModel>> Search(QuestionQueryObject questionQuery);

    Task UpdateListQuestion(QuestionEditModel questionQuery);
}
