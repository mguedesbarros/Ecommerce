using System;
using System.Collections.Generic;
using Ecommerce.Domain.Entities;

namespace Ecommerce.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
