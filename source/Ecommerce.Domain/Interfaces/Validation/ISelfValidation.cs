using System;
using Ecommerce.Domain.Validation;

namespace Ecommerce.Domain.Interfaces.Validation
{
    public interface ISelfValidation
    {
        ValidationResult ValidationResult { get; }
        bool IsValid { get; }
    }
}
