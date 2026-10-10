using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio02.Model
{
    internal class Deposito
    {
        public Dictionary<int, Produto> DepositoProdutos = new Dictionary<int, Produto>();

        public Deposito(Dictionary<int, Produto> depositoProdutos) {
            DepositoProdutos = depositoProdutos;
        }
    }
}
