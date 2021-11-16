using MediatR;
using Microsoft.AspNetCore.Mvc;
using NerdStore.Catalogo.Application.Services;
using NerdStore.Core.Comunication.Mediator;
using NerdStore.Core.Messages.CommonMessages.Notifications;
using NerdStore.Vendas.Application.Commands;
using System;
using System.Threading.Tasks;

namespace NerdStore.WebApps.MVC.Controllers
{


    public class CarrinhoController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IMediatrHandler _mediatrHandler;

        public CarrinhoController(INotificationHandler<DomainNotification> notifications,IProdutoAppService produtoAppService, 
            IMediatrHandler mediatrHandler) : base(notifications,mediatrHandler)
        {
            _produtoAppService = produtoAppService;
            _mediatrHandler = mediatrHandler;   
        }
        public IActionResult Index() => View();
        [HttpPost]
        [Route("meu-carrinho")]
        public async Task<IActionResult> AdicionarItem(Guid id , int quantidade)
        {
            var produto  = await _produtoAppService.ObterPorId(id);
            if (produto is null) return BadRequest();

            if(produto.QuantidadeEstoque < quantidade)
            {
                TempData["Erro"] = "Produto com estoque insufucuente";
                return RedirectToAction("ProdutoDetalhe", "Vitrine", new { id });
            }
            var command = new AdicionarItemPedidoCommand(ClienteId, produto.Id, produto.Nome, quantidade, produto.Valor);
            await _mediatrHandler.EnviarComando(command);
            //Se tudo deu certo?
            if (OperacaoValida())
            {
                return RedirectToAction("Index");
            }
            TempData["Erro"] = "Produto Indisponível";
            return RedirectToAction("ProdutoDetalhe","Vitrine",new {id});
        }
    }
}
