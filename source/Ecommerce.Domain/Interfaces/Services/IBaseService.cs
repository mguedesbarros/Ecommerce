using System;
using System.Collections.Generic;
using Ecommerce.Domain.Entities;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Domain.Interfaces.Services
{
    public interface IBaseService<TEntity>
        where TEntity : BaseEntity
    {
        //ValidationResult Add(TEntity entity);
        //ValidationResult Update(TEntity entity);
        //ValidationResult Delete(TEntity entity);
        //TEntity GetById(int id);
        //IEnumerable<TEntity> GetAll();

        ValidationResult Add<V>(TEntity entity) where V : AbstractValidator<TEntity>;
        ValidationResult Update<V>(TEntity entity) where V : AbstractValidator<TEntity>;
        ValidationResult Delete<V>(TEntity entity) where V : AbstractValidator<TEntity>;

        TEntity GetById(int id);
        IEnumerable<TEntity> GetAll();
    }
}
