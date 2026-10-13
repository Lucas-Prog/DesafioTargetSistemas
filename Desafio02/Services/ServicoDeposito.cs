using Desafio02.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Services
{
    internal class ServicoDeposito
    {
        private readonly Deposito _deposito;
        private Dictionary<int,DepositoLog> depositoLogs = new Dictionary<int, DepositoLog>();
        public ServicoDeposito(Deposito deposito) {
            _deposito = deposito;
        }

        public void AddProdutoEstoque(int id, int quantidade) {
            _deposito.DepositoProdutos[id].Estoque += quantidade;
            GetEstoqueProduto(id);
            GeraLog(id, _deposito.DepositoProdutos[id], TipoMovimentacao.Entrada, quantidade);
        }

        public void RemoveProdutoEstoque(int id, int quantidade) {
            if (_deposito.DepositoProdutos[id].Estoque == 0 || _deposito.DepositoProdutos[id].Estoque-quantidade < 0)
                throw new Exception("Estoque negativado ou tentativa de retirada maior que o estoque disponivel");
            else {
                _deposito.DepositoProdutos[id].Estoque -= quantidade;
            }
            GetEstoqueProduto(id);
            GeraLog(id, _deposito.DepositoProdutos[id], TipoMovimentacao.Saida, quantidade);
        }

        public void GeraLog(int id, Produto produto, TipoMovimentacao tipoMovimentacao, int quantidade) {
            int ultimoLogId = depositoLogs.Count;
            int estoqueAntes = tipoMovimentacao == TipoMovimentacao.Entrada ? produto.Estoque - quantidade : produto.Estoque + quantidade;
            depositoLogs.Add(ultimoLogId + 1, new DepositoLog(
                ultimoLogId + 1,
                produto,
                tipoMovimentacao,
                estoqueAntes,
                produto.Estoque
                ));
            Console.WriteLine(depositoLogs.Last().ToString());
        }

        public void GetEstoqueProduto(int id) {
            if (_deposito.DepositoProdutos.ContainsKey(id)) {
                Console.WriteLine(_deposito.DepositoProdutos[id].CodigoProduto);
                Console.WriteLine(_deposito.DepositoProdutos[id].DescricaoProduto);
                Console.WriteLine(_deposito.DepositoProdutos[id].Estoque);
                Console.WriteLine();
            }
            else
                throw new Exception("Produto não encontrado !");
        }

        public void GetProdutos() {
            foreach(KeyValuePair<int, Produto> item in _deposito.DepositoProdutos) {
                Console.WriteLine(item.Value.CodigoProduto);
                Console.WriteLine(item.Value.DescricaoProduto);
                Console.WriteLine(item.Value.Estoque);
                Console.WriteLine("----------------------------------");
            }
        }
    }
}
