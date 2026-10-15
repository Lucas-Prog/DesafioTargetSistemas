using Desafio01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Services
{
    internal class VendaService
    {
        internal static double GeraComissao(double valorVenda) {
            double comissao = 0;
            double comissaoCalculada = 0;
            if (valorVenda >= 0) {
                if (valorVenda < 100.00)
                    comissao = 0.0;
                else if (valorVenda < 500.00)
                    comissao = 0.01;
                else
                    comissao = 0.05;

                comissaoCalculada = (double)(comissao * valorVenda);
            }
            else {
                Console.WriteLine("O valor da venda não pode ser negativo");
            }

            return comissaoCalculada;

        }
    }
}
