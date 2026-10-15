using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Model
{
    internal class DepositoLog
    {
        public int Id { get; set; }
        public Produto Produto { get; set; }
        public TipoMovimentacao TipoMoviementacao { get; set; }
        public int QuantidadeEstoqueAntes { get; set; }
        public int QuantidadeEstoqueDepois { get; set; }

        public DepositoLog(int id, Produto produto, TipoMovimentacao tipoMovimentacao, int quantidadeEstoqueAntes, int quantidadeEstoqueDepois) {
            Id = id;
            Produto = produto;
            TipoMoviementacao = tipoMovimentacao;
            QuantidadeEstoqueAntes = quantidadeEstoqueAntes;
            QuantidadeEstoqueDepois = quantidadeEstoqueDepois;
        }

        public override string ToString() {
            return $"\nLOG: \n" +
                $"LogId: {Id}\n" +
                $"Codigo Produto: {Produto.CodigoProduto}\n" +
                $"Movimentação: {TipoMoviementacao.ToString()} produto\n" +
                $"Estoque Antes: {QuantidadeEstoqueAntes}\n" +
                $"Estoque atual: {QuantidadeEstoqueDepois}\n";
        }
    }
}
