using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Services
{
    internal class VendaService
    {
        public double GetComissao(double valor) {
            double comissao;
            if (valor >= 0) {
                if (valor < 100.00)
                    comissao = 0.0;
                else if (valor < 500.00)
                    comissao = 0.01;
                else
                    comissao = 0.05;

                return comissao * valor;
            }
            else {
                throw new ArgumentException("O valor da venda não pode ser negativo");
            }

        }
    }
}
