using System;
using System.Collections.Generic;
using Ecommerce.Domain.Validation;

namespace Ecommerce.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity>
        where TEntity : class
    {
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Delete(TEntity entity);
        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
       
    }
}
