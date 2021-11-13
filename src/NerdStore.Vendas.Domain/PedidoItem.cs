﻿using NerdStore.Core.DomainObjects;
using System;

namespace NerdStore.Vendas.Domain
{
    public  class PedidoItem : Entity
    {
        public Guid PedidoId { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string ProdutoNome { get; private set; }
        public int Quantidade { get; private set; }
        public decimal ValorUnitario { get; private set; }

        //EF Relation

        public Pedido Pedido { get; set; }

        public PedidoItem(Guid produtoId, string produtoNome, int quantidade, decimal valorUnitario)
        {
            ProdutoId = produtoId;
            ProdutoNome = produtoNome;
            Quantidade = quantidade;
            ValorUnitario = valorUnitario;
        }
        protected PedidoItem()
        {

        }
        public override bool EhValido()
        {
            return true;
        }
        internal void AssociarPedido(Guid pedidoId)
        {
            PedidoId = pedidoId;
        }
        public decimal CalcularValor() => Quantidade * ValorUnitario;
        internal void AdicionarUnidades(int unidades)
        {
            Quantidade += unidades;
        }
        internal void AtualizarUnidades(int unidades)
        {
            Quantidade = unidades;
        }
    }
}
