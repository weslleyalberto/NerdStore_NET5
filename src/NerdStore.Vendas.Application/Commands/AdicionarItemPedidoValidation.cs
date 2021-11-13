using FluentValidation;
using System;

namespace NerdStore.Vendas.Application.Commands
{
    public class AdicionarItemPedidoValidation : AbstractValidator<AdicionarItemPedidoCommand>
    {
        public AdicionarItemPedidoValidation()
        {
            RuleFor(p => p.ClienteId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do cliente inválido");
            RuleFor(p => p.ProdutoId)
                .NotEqual(Guid.Empty)
                .WithMessage("Id do produto inválido");
            RuleFor(p => p.Nome)
                .NotEmpty()
                .WithMessage("O nome do produto não foi informado");
            RuleFor(p => p.Quantidade)
                .GreaterThan(0)
                .WithMessage("A quantidade mínima de um item é 1");
            RuleFor(p => p.Quantidade)
                .LessThan(15)
                .WithMessage("A quantidade máxima de um item é 15");
            RuleFor(p => p.ValorUnitario)
                .GreaterThan(0)
                .WithMessage("O valor do item precisa ser maior que 0");
           

        }
    }
}
