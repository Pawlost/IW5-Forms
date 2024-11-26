using FormsIW5.BL.Models.Common.Answer;
using FormsIW5.Common.BL.Models.Question;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAnswerFacade : IDetailFacade<AnswerDetailModel>, IListFacade<AnswerListModel>, ICreateFacade<AnswerCreateModel>
{
}
