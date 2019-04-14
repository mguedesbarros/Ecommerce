using System;
using Ecommerce.Domain.Entities;
using FluentValidation;

namespace Ecommerce.Domain.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Não é possível encontrar o objeto Produto");
                });

            RuleFor(c => c.Tipo)
                .NotEmpty().WithMessage("É necessário informar o Tipo do produto.")
                .NotNull().WithMessage("É necessário informar o Tipo do produto.")
                .MaximumLength(30).WithMessage("Tamanho máximo para o Tipo é de 30 caracteres.");


            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("É necessário informar o Nome do produto.")
                .NotNull().WithMessage("É necessário informar o Nome do produto.")
                .MaximumLength(100).WithMessage("Tamanho máximo para o Nome é de 100 caracteres.");

            RuleFor(c => c.Tamanho)
                .NotEmpty().WithMessage("É necessário informar o Tamanho do produto.")
                .NotNull().WithMessage("É necessário informar o Tamanho do produto.")
                .MaximumLength(5).WithMessage("Tamanho máximo para o Tamanho é de 3 caracteres.");

            RuleFor(c => c.Quantidade)
                .NotEmpty().WithMessage("É necessário informar a Quantidade do produto.")
                .NotNull().WithMessage("É necessário informar a Quantidade do produto.");

            RuleFor(c => c.Valor)
                .NotEmpty().WithMessage("É necessário informar o Valor do produto.")
                .NotNull().WithMessage("É necessário informar o Valor do produto.");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("É necessário informar a Descrição do produto.")
                .NotNull().WithMessage("É necessário informar o Descrição do produto.")
                .MaximumLength(500).WithMessage("Tamanho máximo para a Descrição é de 500 caracteres.");

        }
    }
}
