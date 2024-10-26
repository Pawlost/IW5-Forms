using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Common.BL.Models.Question;
using FormsIW5.Common.BL.Models.User;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IQuestionFacade : IDetailFacade<QuestionDetailModel>, IListFacade<QuestionListModel>, ICreateFacade<UserCreateModel>
{
    Task<ICollection<QuestionListModel>> Search(QuestionQueryObject questionQuery);
}
