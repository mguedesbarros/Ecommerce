using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace Ecommerce.Application.Interfaces
{
    public interface IBaseAppService<TEntity>
        where TEntity : class
    {
        ValidationResult Add(TEntity entity);
        ValidationResult Update(TEntity entity);
        ValidationResult Delete(TEntity entity);

        //TEntity Add<V>(TEntity entity) where V : AbstractValidator<TEntity>;
        //TEntity Update<V>(TEntity entity) where V : AbstractValidator<TEntity>;
        //TEntity Delete<V>(TEntity entity) where V : AbstractValidator<TEntity>;

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
