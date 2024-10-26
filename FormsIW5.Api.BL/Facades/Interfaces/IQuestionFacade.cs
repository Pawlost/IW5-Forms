using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IQuestionFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionListModel>, ICreateFacade<QuestionCreateModel>
{
    Task<ICollection<QuestionListModel>> Search(QuestionQueryObject questionQuery);
}
