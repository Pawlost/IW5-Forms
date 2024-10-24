using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Interfaces;
using FormsIW5.Api.DAL.Common.Queries;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

namespace FormsIW5.Api.DAL.Repositories;

public class QuestionRepository : RepositoryBase<QuestionEntity>, IQuestionRepository
{
    public QuestionRepository(
        FormsIW5DbContext dbContext)
        : base(dbContext)
    {
    }

    public async Task<ICollection<QuestionEntity>?> Search(QuestionQueryObject questionQuery)
    {

        return await dbContext.Set<QuestionEntity>().Where(x => !String.IsNullOrEmpty(questionQuery.Text) &&
        !String.IsNullOrEmpty(questionQuery.Description) &&
        !String.IsNullOrEmpty(x.Text) &&
         !String.IsNullOrEmpty(x.Description) &&
        x.Text.Contains(questionQuery.Text) && x.Description.Contains(questionQuery.Description)).ToListAsync();
    }
}
