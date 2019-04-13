using System;
using Ecommerce.Domain.Validation;

namespace Ecommerce.Domain.Interfaces.Validation
{
    public interface IValidation<in TEntity>
    {
        ValidationResult Valid(TEntity entity);
    }
}
