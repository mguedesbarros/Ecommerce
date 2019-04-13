using System;
using System.Collections.Generic;
using Ecommerce.Domain.Interfaces.Repositories;
using Ecommerce.Domain.Interfaces.Services;
using Ecommerce.Domain.Interfaces.Validation;
using Ecommerce.Domain.Validation;

namespace Ecommerce.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class
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

        public ValidationResult Add(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            baseRepository.Add(entity);

            return validationResult;
        }

        public ValidationResult Delete(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            baseRepository.Delete(entity);

            return validationResult;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return baseRepository.GetById(id);
        }

        public ValidationResult Update(TEntity entity)
        {
            if (!ValidationResult.IsValid)
                return ValidationResult;

            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid)
                return selfValidationEntity.ValidationResult;

            baseRepository.Update(entity);

            return validationResult;
        }
    }
}
