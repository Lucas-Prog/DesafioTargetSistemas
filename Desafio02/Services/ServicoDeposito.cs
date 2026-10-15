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
            if(quantidade > 0) {
                _deposito.DepositoProdutos[id].Estoque += quantidade;
                GeraLog(id, _deposito.DepositoProdutos[id], TipoMovimentacao.Entrada, quantidade);
            }
            else {
                Console.WriteLine("Operação invalida, a quantidade não pode ser menor ou igual a 0");
            }
        }

        public bool RemoveProdutoEstoque(int id, int quantidade) {
            bool retorno = false;
            if (quantidade > 0) {
                if (_deposito.DepositoProdutos[id].Estoque == 0 || _deposito.DepositoProdutos[id].Estoque-quantidade < 0) {

                    Console.WriteLine("Estoque negativado ou tentativa de retirada maior que o estoque disponivel");
                    GetEstoqueProduto(id);
                }
                else {
                    _deposito.DepositoProdutos[id].Estoque -= quantidade;
                    GeraLog(id, _deposito.DepositoProdutos[id], TipoMovimentacao.Saida, quantidade);
                    retorno = true;
                }
            }
            else {
                Console.WriteLine("Operação invalida, a saida de estoque não pode ser indicada com sinal -, ou igual a 0");
            }
            return retorno;
        }

        private void GeraLog(int id, Produto produto, TipoMovimentacao tipoMovimentacao, int quantidade) {
            int ultimoLogId = depositoLogs.Count;
            int estoqueAntes = tipoMovimentacao == TipoMovimentacao.Entrada ? produto.Estoque - quantidade : produto.Estoque + quantidade;
            depositoLogs.Add(ultimoLogId + 1, new DepositoLog(
                ultimoLogId + 1,
                produto,
                tipoMovimentacao,
                estoqueAntes,
                produto.Estoque
                ));
            Console.WriteLine(depositoLogs.Last().Value.ToString());
        }

        public bool VerificaProduto(int codId) {
            return _deposito.DepositoProdutos.ContainsKey(codId);
        }

        public void GetEstoqueProduto(int id) {
            if (_deposito.DepositoProdutos.ContainsKey(id)) {
                Console.WriteLine($"\n" +
                                  $"Código: {_deposito.DepositoProdutos[id].CodigoProduto}\n" +
                                  $"Produto: {_deposito.DepositoProdutos[id].DescricaoProduto}\n" +
                                  $"Estoque: {_deposito.DepositoProdutos[id].Estoque}\n");
            }
            else
                Console.WriteLine("Produto não encontrado !");
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
