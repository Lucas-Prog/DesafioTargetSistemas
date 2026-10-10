using Desafio02.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Services
{
    internal class ServicoDeposito
    {
        private readonly Deposito _deposito;
        public ServicoDeposito(Deposito deposito) {
            _deposito = deposito;
        }

        public void AddProdutoEstoque(int id, int quantidade) {
            _deposito.DepositoProdutos[id].Estoque += quantidade;
            GetEstoqueProduto(id);
        }

        public void RemoveProdutoEstoque(int id, int quantidade) {
            if (_deposito.DepositoProdutos[id].Estoque == 0 || _deposito.DepositoProdutos[id].Estoque-quantidade < 0)
                throw new Exception("Estoque negativado ou tentativa de retirada maior que o estoque disponivel");
            else {
                _deposito.DepositoProdutos[id].Estoque -= quantidade;
            }
            GetEstoqueProduto(id);
        }

        public void GetEstoqueProduto(int id) {
            if (_deposito.DepositoProdutos.ContainsKey(id)) {
                Console.WriteLine(_deposito.DepositoProdutos[id].CodigoProduto);
                Console.WriteLine(_deposito.DepositoProdutos[id].DescricaoProduto);
                Console.WriteLine(_deposito.DepositoProdutos[id].Estoque);
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
