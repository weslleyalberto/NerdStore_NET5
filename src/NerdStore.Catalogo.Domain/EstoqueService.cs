using NerdStore.Catalogo.Domain.Events;
using NerdStore.Core.Comunication.Mediator;
using System;
using System.Threading.Tasks;

namespace NerdStore.Catalogo.Domain
{
    public class EstoqueService : IEstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMediatrHandler _bus;
        public EstoqueService(IProdutoRepository produtoRepository, IMediatrHandler bus)
        {
            _produtoRepository = produtoRepository;
            _bus = bus;
        }
        public async Task<bool> DebitarEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto is null)
            {
                return false;
            }
            if (!produto.Possuiestoque(quantidade))
            {
                return false;
            }
            produto.DebitarEstoque(quantidade);
            //TODO - Parametrizar a quantidade de estoque baixo
            if (produto.QuantidadeEstoque < 10)
            {
                //avisar , email , chamado , realizar nova compra 
                await _bus.PublicarEvento(new ProdutoAbaixoEstoqueEvent(produtoId, produto.QuantidadeEstoque));
            }
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }

        public void Dispose()
        {
            _produtoRepository?.Dispose();
        }

        public async Task<bool> ReporEstoque(Guid produtoId, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);
            if (produto is null)
            {
                return false;
            }
            produto.ReporEstoque(quantidade);
            _produtoRepository.Atualizar(produto);
            return await _produtoRepository.UnitOfWork.Commit();
        }
    }
}
