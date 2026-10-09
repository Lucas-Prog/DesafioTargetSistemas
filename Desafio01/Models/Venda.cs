using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Models
{
    internal class Venda
    {
        public Vendedor Vendedor { get; set; }
        public double Valor { get; set; }

        public Venda(Vendedor vendedor, double valor) {
            Vendedor = vendedor;
            Valor = valor;
        }

        public double GetComission() {
            if (Valor < 100.00)
                return 0.0;
            if (Valor < 500.00)
                return Valor * 0.01;
            else
                return Valor * 0.05;
        }

    }
}
