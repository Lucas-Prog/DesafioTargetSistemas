using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Models
{
    internal class Venda
    {
        public string Vendedor { get; set; }
        public double Valor { get; set; }

        public Venda() {
        }
        public Venda(string vendedor, double valor) {
            Vendedor = vendedor;
            Valor = valor;
        }
    }
}
