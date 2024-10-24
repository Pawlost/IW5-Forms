using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Common.Repositories;
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
        !String.IsNullOrEmpty(x.QuestionText) &&
         !String.IsNullOrEmpty(x.Description) &&
        x.QuestionText.Contains(questionQuery.Text) && x.Description.Contains(questionQuery.Description)).ToListAsync();
    }

    public override async Task<Guid> InsertAsync(QuestionEntity entity)
    {
        var form = await dbContext.Set<FormEntity>().Include(f => f.Questions).SingleOrDefaultAsync(f => f.Id == entity.FormId);
        form?.Questions.Add(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public override async Task<QuestionEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<QuestionEntity>().Include(q => q.Answers).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}
