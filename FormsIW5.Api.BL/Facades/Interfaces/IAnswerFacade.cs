using FormsIW5.BL.Models.Common.Answer;

namespace FormsIW5.Api.BL.Facades.Interfaces;

public interface IAnswerFacade : IDetailFacade<AnswerDetailModel>, IListFacade<AnswerListModel>, ICreateFacade<AnswerCreateModel>
{
}
