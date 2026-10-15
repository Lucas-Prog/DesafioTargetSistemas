using Desafio01.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Desafio01.Services
{
    internal class VendedorService
    {        
        public string CalculaComissao(List<Venda> vendas) {
            double comissao = 0;
            foreach (Venda venda in vendas) {
                comissao += VendaService.GeraComissao(venda.ValorVenda);
            }
            return $"R$ {comissao.ToString("F2")}";
        }
    }
}
