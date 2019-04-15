using System;
using System.Collections.Generic;
using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using FluentValidation;
using FluentValidation.Results;

namespace Ecommerce.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly IBaseRepository<TEntity> baseRepository;
        protected readonly ValidationResult validationResult;

        public BaseService(IBaseRepository<TEntity> baseRepository, ValidationResult validationResult)
        {
            this.baseRepository = baseRepository;
            this.validationResult = validationResult;
        }

        protected ValidationResult ValidationResult
        {
            get { return validationResult; }
        }

        public ValidationResult Add<V>(TEntity entity) where V : AbstractValidator<TEntity>
        {
            var validation = Validate(entity, Activator.CreateInstance<V>());

            if(validation.IsValid)
                baseRepository.Add(entity);

            return validation;
        }

        public ValidationResult Delete<V>(TEntity entity) where V : AbstractValidator<TEntity>
        {
            var validation = Validate(entity, Activator.CreateInstance<V>());

            if (validation.IsValid)
                baseRepository.Delete(entity);

            return validation;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public ValidationResult Update<V>(TEntity entity) where V : AbstractValidator<TEntity>
        {
            var validation = Validate(entity, Activator.CreateInstance<V>());

            if (validation.IsValid)
                baseRepository.Update(entity);

            return validation;
        }

        private ValidationResult Validate(TEntity entity, AbstractValidator<TEntity> validator)
        {
            if (entity == null)
                throw new Exception("Nenhum registro encontrado!");

            return validator.Validate(entity);
        }
    }
}
