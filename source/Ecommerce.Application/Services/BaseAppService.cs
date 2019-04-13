using System;
using System.Collections.Generic;
using Ecommerce.Application.Interfaces;
using Ecommerce.Domain.Validation;
using Ecommerce.Infra.Data.Context.Interfaces;

namespace Ecommerce.Application.Services
{
    public class BaseAppService
    {
        public BaseAppService()
        {
            ValidationResult = new ValidationResult();
        }
        protected ValidationResult ValidationResult { get; private set; }
    }
}
