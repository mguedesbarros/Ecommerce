using System;
using Ecommerce.Domain.Entities;
using FluentValidation;

namespace Ecommerce.Domain.Validators
{
    public class ProdutoExclusaoValidador : AbstractValidator<Produto>
    {
        public ProdutoExclusaoValidador()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não é possível encontrar o objeto Produto");
                });

            RuleFor(c => c.Id)
                .NotEmpty().WithMessage("É necessário informar o Id do produto.")
                .NotNull().WithMessage("É necessário informar o Id do produto.");
        }
    }
}
