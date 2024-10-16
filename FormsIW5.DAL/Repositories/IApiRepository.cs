using FormsIW5.DAL.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormsIW5.DAL.Repositories;

public interface IApiRepository<TEntity>
    where TEntity : IEntity
{
    IList<TEntity> GetAll();
    TEntity? GetById(Guid id);
    Guid Insert(TEntity entity);
    Guid? Update(TEntity entity);
    void Remove(Guid id);
    bool Exists(Guid id);
}
