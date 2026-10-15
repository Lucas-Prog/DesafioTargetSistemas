using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Models
{
    internal class Venda
    {
        public string Vendedor { get; set; }
        public double ValorVenda { get; set; }

        public Venda(string vendedor, double valorVenda) {
            Vendedor = vendedor;
            ValorVenda = valorVenda;
        }
    }
}
