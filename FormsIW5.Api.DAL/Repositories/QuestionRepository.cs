using FormsIW5.Api.DAL.Common.Entities;
using FormsIW5.Api.DAL.Common.Queries;
using FormsIW5.Api.DAL.Common.Repositories;
using Microsoft.EntityFrameworkCore;

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

        var isQueryEmpty = String.IsNullOrEmpty(questionQuery.Text) && String.IsNullOrEmpty(questionQuery.Description);

        var query = dbContext.Set<QuestionEntity>().Where(q => q.FormId == questionQuery.FormId);
        
        if (!isQueryEmpty) {
            query = query.Where(x =>
               !(String.IsNullOrEmpty(x.QuestionText) || String.IsNullOrEmpty(x.Description)) &&
               (x.QuestionText.Contains(questionQuery.Text) || x.Description.Contains(questionQuery.Description))
           );
        }
        return await query.ToListAsync();
    }

    public override async Task<QuestionEntity?> GetByIdAsync(Guid id)
    {
        return await dbContext.Set<QuestionEntity>().Include(q => q.Answers).Include(q => q.QuestionOptions).SingleOrDefaultAsync(entity => entity.Id == id);
    }
}
