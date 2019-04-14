using System;
using System.Collections.Generic;
using Ecommerce.Application.Interfaces;
using Ecommerce.Infra.Data.Context.Interfaces;
using FluentValidation.Results;

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
